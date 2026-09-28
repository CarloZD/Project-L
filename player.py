"""Jugador provisional: un cuadrado verde controlado con WASD o flechas."""

import pygame

import settings


class Player:
    def __init__(self, x, y):
        # Posición real en coma flotante para que el movimiento sea suave
        # aunque cada frame avance fracciones de píxel.
        self.pos = pygame.Vector2(x, y)
        self.rect = pygame.Rect(0, 0, settings.TAMANO_JUGADOR, settings.TAMANO_JUGADOR)
        self.rect.center = (round(x), round(y))
        self.velocidad = settings.VELOCIDAD_JUGADOR
        self.direccion = pygame.Vector2(0, 0)

    def leer_entrada(self):
        """Traduce las teclas pulsadas a una dirección de movimiento."""
        teclas = pygame.key.get_pressed()
        dx = (teclas[pygame.K_d] or teclas[pygame.K_RIGHT]) - (teclas[pygame.K_a] or teclas[pygame.K_LEFT])
        dy = (teclas[pygame.K_s] or teclas[pygame.K_DOWN]) - (teclas[pygame.K_w] or teclas[pygame.K_UP])
        self.direccion.update(dx, dy)

        # Normalizar evita que en diagonal se mueva más rápido (~41 % extra).
        if self.direccion.length_squared() > 0:
            self.direccion = self.direccion.normalize()

    def update(self, dt, limites):
        """Mueve al jugador según el tiempo transcurrido y lo mantiene dentro de los límites.

        dt: segundos desde el frame anterior.
        limites: pygame.Rect del área en la que se puede mover.
        """
        self.leer_entrada()
        self.pos += self.direccion * self.velocidad * dt

        # Límites de pantalla: se limita la posición real (no la redondeada)
        # para no perder las fracciones de píxel en cada frame.
        mitad_w = self.rect.width / 2
        mitad_h = self.rect.height / 2
        self.pos.x = max(limites.left + mitad_w, min(self.pos.x, limites.right - mitad_w))
        self.pos.y = max(limites.top + mitad_h, min(self.pos.y, limites.bottom - mitad_h))

        self.rect.center = (round(self.pos.x), round(self.pos.y))

    def draw(self, superficie):
        pygame.draw.rect(superficie, settings.COLOR_JUGADOR, self.rect)

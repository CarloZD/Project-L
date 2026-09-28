"""Control del juego: ventana, ciclo principal y coordinación de los sistemas."""

import sys

import pygame

import settings
from player import Player


class Game:
    def __init__(self):
        pygame.init()
        self.pantalla = pygame.display.set_mode((settings.ANCHO, settings.ALTO))
        pygame.display.set_caption(settings.TITULO)
        self.reloj = pygame.time.Clock()
        self.ejecutando = True

        self.limites = self.pantalla.get_rect()
        self.jugador = Player(settings.ANCHO / 2, settings.ALTO / 2)

    # Ciclo principal: eventos, actualización y dibujo, 60 veces por segundo.
    def run(self):
        while self.ejecutando:
            # tick() limita a FPS y devuelve los milisegundos del frame.
            dt = self.reloj.tick(settings.FPS) / 1000
            self.manejar_eventos()
            self.actualizar(dt)
            self.dibujar()

        pygame.quit()
        sys.exit()

    def manejar_eventos(self):
        for evento in pygame.event.get():
            if evento.type == pygame.QUIT:
                self.ejecutando = False
            elif evento.type == pygame.KEYDOWN and evento.key == pygame.K_ESCAPE:
                self.ejecutando = False

    def actualizar(self, dt):
        self.jugador.update(dt, self.limites)

        if settings.MOSTRAR_FPS:
            pygame.display.set_caption(f"{settings.TITULO}  |  {self.reloj.get_fps():.0f} FPS")

    def dibujar(self):
        self.pantalla.fill(settings.COLOR_FONDO)
        self.jugador.draw(self.pantalla)
        pygame.display.flip()

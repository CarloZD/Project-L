# Project Hero "L"

> Videojuego RPG 2D desarrollado en Python y Pygame.

## 📖 Descripción

**Project Hero "L"** es un proyecto personal de desarrollo de videojuegos que busca transformar un universo narrativo original, creado durante varios años, en una experiencia interactiva.

El proyecto combina el aprendizaje de programación con la creación de un RPG en 2D centrado en la exploración, el combate, la progresión del protagonista y el desarrollo de una historia original.

La historia gira en torno a Leo, un héroe que deberá enfrentarse a diferentes enemigos, desarrollar sus habilidades y afrontar las consecuencias de sus propias decisiones.

Durante las primeras etapas, el desarrollo se centrará en construir una base técnica sólida y modular utilizando Python y Pygame. Posteriormente, se incorporarán los personajes, escenarios, enemigos y acontecimientos del universo narrativo.

El objetivo a largo plazo es desarrollar un videojuego funcional que permita explorar el universo de Leo de manera interactiva.

---

## 🎯 Objetivos

- Aprender desarrollo de videojuegos mediante Python y Pygame.
- Diseñar una arquitectura modular, organizada y escalable.
- Implementar progresivamente las mecánicas principales de un RPG.
- Crear sistemas independientes y reutilizables.
- Desarrollar escenarios, personajes, enemigos y objetos interactivos.
- Implementar exploración, combate, inventario y progresión.
- Integrar posteriormente el universo narrativo de Leo.
- Transformar una historia creada durante años en una experiencia interactiva.

---

## 🛠️ Tecnologías

| Tecnología | Uso |
|---|---|
| Python | Lenguaje de programación |
| Pygame | Desarrollo del videojuego |
| Visual Studio Code | Editor de código |
| Git | Control de versiones |

---

## ▶️ Cómo ejecutar

Requisitos: Python 3.10 o superior.

```bash
pip install -r requirements.txt
python main.py
```

Controles: **WASD** o **flechas** para moverse, **Esc** para salir.

### Estructura actual

```
Project L/
├── main.py           # Punto de entrada
├── settings.py       # Configuración general (ventana, colores, velocidad)
├── game.py           # Control del juego y ciclo principal
├── player.py         # Jugador provisional
├── requirements.txt
└── README.md
```

---

## 🗺️ Roadmap

El desarrollo seguirá una metodología incremental. Cada sistema será implementado y probado antes de continuar con el siguiente.

### Fase 1: Base del juego

Construir una ventana funcional donde el jugador esté representado inicialmente por un cuadrado verde.

- [x] Crear la ventana del juego.
- [x] Implementar el ciclo principal.
- [x] Configurar una actualización de 60 FPS.
- [x] Crear el personaje provisional.
- [x] Implementar movimiento mediante WASD y flechas.
- [x] Establecer los límites de pantalla.
- [x] Implementar el control básico del personaje.

### Fase 2: Mundo

Crear un escenario donde el jugador pueda desplazarse e interactuar con el entorno.

- [ ] Crear mapas.
- [ ] Implementar obstáculos.
- [ ] Añadir colisiones.
- [ ] Crear diferentes zonas.
- [ ] Implementar transiciones entre mapas.
- [ ] Crear una cámara básica.

### Fase 3: Personajes

Incorporar entidades dentro del mundo.

- [ ] Implementar personajes no jugables (NPC).
- [ ] Crear diálogos básicos.
- [ ] Añadir enemigos.
- [ ] Implementar comportamientos sencillos.
- [ ] Permitir la interacción con personajes y objetos.

### Fase 4: Sistema de combate

Implementar un sistema de combate en tiempo real.

- [ ] Implementar ataques básicos.
- [ ] Crear el sistema de vida y daño.
- [ ] Permitir derrotar enemigos.
- [ ] Implementar tiempo de invulnerabilidad.
- [ ] Añadir animaciones básicas.

### Fase 5: Inventario y equipamiento

Desarrollar un sistema que permita administrar los objetos del jugador.

- [ ] Recoger objetos.
- [ ] Administrar el inventario.
- [ ] Equipar armas.
- [ ] Cambiar armaduras.
- [ ] Utilizar objetos consumibles.

Posteriormente se incorporarán armas del universo, como la Espada de la Luz y la Espada del Caos.

### Fase 6: Progresión

Implementar mecánicas de crecimiento del personaje.

- [ ] Añadir experiencia.
- [ ] Crear niveles.
- [ ] Implementar estadísticas.
- [ ] Añadir habilidades.
- [ ] Permitir mejorar al personaje.

### Fase 7: Misiones

Crear un sistema de objetivos y actividades.

- [ ] Implementar misiones principales.
- [ ] Implementar misiones secundarias.
- [ ] Añadir recompensas.
- [ ] Crear seguimiento del progreso.

### Fase 8: Guardado

Implementar un sistema de persistencia.

- [ ] Guardar partidas.
- [ ] Cargar partidas.
- [ ] Implementar diferentes perfiles de guardado.

### Fase 9: Integración narrativa

Incorporar progresivamente el universo de Leo.

- [ ] Integrar al protagonista.
- [ ] Incorporar personajes principales y secundarios.
- [ ] Crear escenarios narrativos.
- [ ] Implementar diálogos y eventos.
- [ ] Añadir enemigos principales.
- [ ] Crear jefes.
- [ ] Implementar cinemáticas.
- [ ] Desarrollar la historia.

---

## 🧱 Arquitectura del proyecto

El código se organizará mediante módulos independientes, evitando concentrar toda la lógica del juego en un único archivo.

Se contemplan módulos para:

- Configuración general.
- Control del juego.
- Jugador.
- Enemigos.
- Mundo y mapas.
- Colisiones.
- Combate.
- Inventario.
- Interfaz.
- Sonido.
- Guardado de partidas.
- Eventos narrativos.

También se utilizarán carpetas para almacenar recursos gráficos, mapas, música, efectos de sonido y otros elementos necesarios.

La estructura definitiva se establecerá durante el desarrollo técnico.

### Principios de desarrollo

- Mantener el código organizado y legible.
- Evitar la duplicación innecesaria de código.
- Separar las responsabilidades de cada módulo.
- Facilitar la reutilización de sistemas.
- Probar cada funcionalidad antes de integrarla.
- Priorizar una arquitectura fácil de mantener y ampliar.

---

# 🌌 Universo narrativo

## 1. Origen

El universo de Project Hero "L" está basado en una historia original creada durante la infancia del desarrollador.

La historia comenzó como una aventura protagonizada por Leo, un héroe elegido que obtiene una espada mágica y se enfrenta a diferentes enemigos.

Con el paso de los años, el universo fue creciendo mediante la incorporación de nuevos personajes, poderes, conflictos y acontecimientos.

La historia combina influencias de diferentes obras de fantasía, ciencia ficción y anime, junto con elementos originales desarrollados a lo largo de sus distintos arcos argumentales.

## 2. El protagonista: Leo

Leo es el protagonista principal de la historia.

Inicialmente es presentado como un héroe elegido que obtiene una armadura y una espada especial. A lo largo de su aventura desarrolla sus habilidades y participa en diferentes enfrentamientos.

Sin embargo, su historia no se limita a convertirse en el héroe más poderoso.

Uno de sus principales conflictos está relacionado con su arrogancia y su deseo de superar sus propios límites.

Sus decisiones tienen consecuencias que afectan tanto su vida como la de las personas que lo rodean.

A lo largo de la historia, Leo deberá enfrentarse a las consecuencias de sus actos y comprender los límites de su propio poder.

## 3. Las espadas legendarias

Dentro del universo existen dos armas especialmente importantes.

### Espada de la Luz

Es una de las armas principales de la historia y está relacionada con el poder que inicialmente representa el lado heroico de Leo.

### Espada del Caos

Es una espada que contiene un poder capaz de controlar a quien intenta dominarla.

Su influencia representa uno de los principales conflictos del protagonista.

Aunque ambas armas poseen un gran poder, su utilización implica consecuencias que van más allá de la fuerza física.

## 4. El sistema de héroes y armaduras

El universo cuenta con diferentes héroes que poseen habilidades especiales.

Inicialmente, las armaduras fueron concebidas como una fuente de poder. Sin embargo, posteriormente se estableció que las habilidades pertenecen realmente a los propios héroes, mientras que las armaduras sirven para ayudarlos a controlar y canalizar esas capacidades.

Leo obtiene su primera armadura de manera accidental, al irrumpir en la prueba destinada a otro héroe.

Este acontecimiento marca uno de los primeros pasos de su aventura.

## 5. Primer arco argumental

El primer arco presenta el origen de Leo y su enfrentamiento contra un enemigo que utiliza una espada relacionada con un poder superior.

Durante el enfrentamiento, Leo muere, pero posteriormente resucita y obtiene un poder extraordinario que le permite derrotar al enemigo.

Sin embargo, el villano no era más que un instrumento de una fuerza vinculada a su espada.

Después de la victoria, Leo intenta dominar ambas espadas, convencido de que puede controlar sus poderes.

La Espada del Caos termina dominándolo.

Cuando recupera la conciencia, descubre que el escenario ha quedado destruido y que ha perdido su brazo derecho.

Rojo, su líder, le explica que perdió el control mientras estaba bajo la influencia de la espada, provocando la muerte de varios de sus aliados y la destrucción del lugar.

Como consecuencia, Leo es desterrado.

Este acontecimiento marca un punto de inflexión en su historia, ya que pasa de ser un héroe victorioso a convertirse en alguien que debe afrontar las consecuencias de sus propias acciones.

## 6. Leo Sombrío

Después de perder su brazo derecho, la influencia de la Espada del Caos continúa consumiéndolo.

Como consecuencia, el brazo termina separándose y de él se manifiesta un segundo cuerpo idéntico a Leo.

Este nuevo personaje es conocido como **Leo Sombrío** y posee una armadura negra.

Su aparición funciona como una consecuencia directa de los acontecimientos del primer arco y representa el surgimiento de una nueva amenaza dentro del universo.

## 7. Desarrollo posterior

La historia continúa a través de diferentes arcos argumentales que desarrollan nuevos conflictos, personajes y acontecimientos.

Leo permanece como protagonista hasta el final de su historia.

Durante su recorrido aparecen nuevos héroes, enemigos y desafíos que amplían progresivamente el universo.

La historia también incorpora conflictos relacionados con la ambición, el poder, la rivalidad y las consecuencias de las decisiones personales.

El desarrollo completo de estos acontecimientos se realizará posteriormente, cuando el proyecto avance hacia su etapa narrativa.

---

## ⚔️ Concepto del juego

Project Hero "L" será un RPG en 2D centrado en:

- Exploración de escenarios.
- Combate contra enemigos.
- Progresión del protagonista.
- Obtención de objetos y equipamiento.
- Desarrollo de habilidades.
- Enfrentamientos contra jefes.
- Interacción con personajes.
- Desarrollo de una historia original.

El sistema de combate será en tiempo real.

El protagonista comenzará representado mediante una figura simple y posteriormente será reemplazado por Leo, incluyendo sus diferentes diseños y armaduras.

La historia no será implementada durante la primera etapa. Primero se desarrollarán las mecánicas necesarias para que el personaje pueda desplazarse, interactuar con el mundo y combatir.

---

## 📌 Alcance inicial

La primera versión del proyecto se centrará en construir una base funcional que permita:

- Mover al personaje.
- Explorar escenarios.
- Interactuar con objetos.
- Implementar colisiones.
- Desarrollar un sistema de combate básico.

El protagonista será representado inicialmente mediante una figura simple.

La prioridad será comprobar el funcionamiento de los sistemas fundamentales y establecer una estructura organizada para el desarrollo futuro.

La historia completa no formará parte de esta primera versión.

---

## 🔮 Alcance futuro

A largo plazo se contempla incorporar:

- Historia completa de Leo.
- Diferentes regiones y escenarios.
- Sistema de héroes.
- Armaduras especiales.
- Habilidades únicas.
- Árboles de habilidades.
- Enemigos con comportamientos avanzados.
- Jefes finales.
- Mazmorras.
- Ciudades.
- Efectos climáticos.
- Ciclo de día y noche.
- Música y efectos de sonido.
- Cinemáticas.
- Sistema de decisiones.
- Logros y coleccionables.

Estas características se implementarán progresivamente, según las necesidades del proyecto y el aprendizaje adquirido durante el desarrollo.

---

## 🚧 Estado actual

**Etapa:** Fase 1 completada (base del juego).

**Versión del documento de visión:** 1.1

Actualmente se cuenta con una visión definida del proyecto, sus objetivos, tecnologías, universo narrativo y fases de desarrollo.

La Fase 1 ya cuenta con una ventana a 60 FPS y un personaje provisional que se mueve con WASD o flechas dentro de los límites de pantalla.

El siguiente paso será comenzar la Fase 2: Mundo.

---

## 👤 Autor

**Carlos Ruiz Llanterhuay**

Proyecto personal de aprendizaje y desarrollo de videojuegos.

---

## 🎮 Visión a largo plazo

Project Hero "L" busca convertirse en un videojuego RPG en 2D basado en el universo original de Leo.

El proyecto combinará el aprendizaje técnico con el desarrollo creativo, permitiendo transformar una historia imaginada durante años en una experiencia interactiva.

La construcción del videojuego se realizará de manera progresiva, priorizando una base sólida, organizada y escalable.

El objetivo no será únicamente terminar un juego en poco tiempo, sino desarrollar un proyecto personal que pueda evolucionar durante años.

**La meta final es dar vida al universo de Leo mediante un videojuego propio, construido paso a paso.**
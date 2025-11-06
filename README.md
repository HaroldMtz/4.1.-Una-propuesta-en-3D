# Actividad 4.2 – Movimiento en el espacio tridimensional

## Objetivo
Desarrollar las dinámicas de juego necesarias para mover al personaje en el espacio tridimensional, además de implementar una curva de dificultad progresiva y guardado de datos (Score y HighScore).

## Descripción del proyecto
En este videojuego 3D, el jugador controla un personaje que puede moverse libremente en el espacio tridimensional mediante un joystick virtual o teclas.  
A medida que el jugador avanza, se incrementa un contador de puntos basado en la distancia recorrida.  
El juego incluye una curva de dificultad progresiva que aumenta la velocidad del personaje con el tiempo, y un sistema de guardado que almacena el HighScore.

## Componentes desarrollados
- **PlayerMotor.cs** → Movimiento del personaje (Rigidbody, salto, joystick).  
- **DifficultyCurve.cs** → Aumento gradual de la velocidad del jugador.  
- **ScoreSystem.cs** → Cálculo de Score, HighScore y guardado persistente.  
- **SaveService.cs** → Manejo de datos con PlayerPrefs.  
- **Canvas HUD** → Interfaz con textos de Score y HighScore visibles.

## Criterios de evaluación cumplidos
✅ Movimiento en el espacio 3D.  
✅ Curva de dificultad progresiva.  
✅ Guardado de datos (HighScore).  
✅ Contador visible que incrementa según la interacción del jugador.  
✅ Repositorio público para revisión.

## Cómo ejecutar
1. Abrir el proyecto en **Unity 2021.3+**.  
2. Abrir la escena principal (`Nivel1.unity`).  
3. Ejecutar en modo **Play**.  
4. Mover el joystick o las teclas para avanzar.  
5. Observar el aumento del Score y del HighScore.

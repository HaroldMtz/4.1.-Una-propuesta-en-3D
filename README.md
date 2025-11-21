4.5 – Interfaz y Navegación del Videojuego 3D

Este repositorio contiene el desarrollo de la actividad 4.5 Interfaz y Navegación, correspondiente al proyecto de videojuego 3D para Android realizado en Unity.

El objetivo de esta actividad fue implementar las interfaces de usuario y la navegación entre escenas, asegurando que el jugador pueda acceder correctamente al menú principal, niveles y pantalla de fin de juego.

📌 Características principales del proyecto
✔ Menú Principal (MainMenu)

Botón Jugar que inicia el juego cargando Level1.

Botón Salir con compatibilidad para Android.

UI adaptada a pantallas móviles (Canvas con “Scale With Screen Size”).

Navegación gestionada con el script UINavigator.cs.

✔ Nivel 1 (Level1) – Generación infinita

Nivel tipo endless, con plataformas generadas aleatoriamente.

Dificultad progresiva (velocidad aumenta según distancia).

El nivel termina y pasa a Level2 cuando el jugador recorre 200 unidades.

Controlado por el script LevelManager.cs.

✔ Nivel 2 (Level2) – Infinity + Objetivo por Score

También es un nivel infinito.

Cuenta puntos según la distancia recorrida usando el script ScoreSystem.cs.

El nivel termina cuando el jugador alcanza 50 puntos.

Al alcanzar 50 puntos, el juego regresa automáticamente al Menú Principal.

Todo gestionado con la actualización final del LevelManager.cs.

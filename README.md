# 🎮 Actividad 4.3 - Niveles de Juego (Unity 3D)

## 🧩 Descripción
Videojuego 3D para móvil donde el jugador avanza por una plataforma infinita, recoge monedas y su velocidad aumenta conforme progresa.  
Si cae del escenario, el nivel se reinicia automáticamente.

---

## ⚙️ Funcionalidades
- Niveles generados de forma infinita.
- Curva de dificultad progresiva (aumento de velocidad).
- Reinicio automático al perder.
- Monedas que suman puntos al ser recolectadas.
- Compatible con controles por joystick móvil.

---

## 🗂️ Scripts principales
- **PlayerMotor.cs** → movimiento y salto del jugador.  
- **LevelManager.cs** → genera y destruye plataformas dinámicamente.  
- **ScoreSystem.cs** → muestra y guarda el puntaje.  
- **Coin.cs** → detección y suma de monedas.  
- **GameManager.cs** → reinicia el nivel.

# 🎮 Proyecto 4.1 – Una Propuesta en 3D  
## Unity – Videojuego tipo HelixJump con mejoras UX

Este proyecto corresponde a la actividad **4.1 – Una propuesta en 3D**, del curso de Desarrollo de Aplicaciones Interactivas en la UnADM.  
Se trata de un videojuego 3D inspirado en el estilo HelixJump, mejorado con efectos de experiencia de usuario (UX) como barra de velocidad, partículas, power-ups y variación dinámica de dificultad.

---

## 🟣 Objetivo de la Actividad

Implementar efectos visuales y de jugabilidad que **enriquezcan la experiencia del usuario** mediante:

- Cambios temporales de velocidad del personaje
- Animaciones visuales rápidas (estelas / partículas)
- Barra de progreso durante el efecto de velocidad
- Cambio de color y retroalimentación visual
- Dificultad progresiva a lo largo del nivel

---

## 🟩 Características del Videojuego

### ✔ Movimiento 3D fluido con joystick virtual  
El personaje se controla mediante un joystick para dispositivos móviles, manteniendo una respuesta suave y estable.

### ✔ Salto con botón (Android Ready)  
Sistema de salto compatible con Android, utilizando raycast para detectar el suelo.

### ✔ Sistema de Boost (Super Speed)
Al obtener un **Power-Up**, el personaje entra en modo de velocidad especial:

- Aumenta temporalmente su `moveSpeed`
- Se muestra una **barra de duración**
- Se activan **partículas SpeedLines**
- El personaje cambia visualmente de color
- La velocidad se restaura automáticamente al terminar

### ✔ Sistema de Dificultad Progresiva  
La velocidad base aumenta sutilmente cada cierto tiempo sin interferir con el boost.

### ✔ Partículas y efectos visuales  
- Líneas de velocidad (SpeedLines)
- Efecto de color en el modelo
- UI Slider con animación de tiempo

### ✔ Múltiples niveles (Level1 y Level2)
Ambas escenas cuentan con:

- Player funcional
- Power-Up
- Movimiento + salto
- Boost
- Barra de velocidad
- Dificultad progresiva

---

## 🟦 Controles del Juego

### 🕹️ Movimiento  
- Joystick virtual (Android y PC con mouse arrastrando)

### ⤴️ Salto  
- Botón “Jump”

### ⚡ Boost  
- Se activa automáticamente al tocar un **Power-Up**

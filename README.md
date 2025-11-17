# 4.4 Iluminación y mejoras visuales 🎮

Proyecto de videojuego 3D tipo **Helix Jump / plataforma móvil**, desarrollado en Unity, como parte de la actividad **4.4 Iluminación y mejoras visuales**.

En esta versión se configuró la iluminación de la escena y un sistema de colores dinámicos para el fondo y el personaje.

---

## 🎯 Objetivo de la actividad

Implementar una gestión básica de iluminación y mejoras visuales que permita:

- Cambiar el **color de fondo** del juego.
- Cambiar el **color del personaje**.
- Ajustar la **iluminación principal** de la escena.

---

## 🛠️ Implementación

### Script `VisualManager.cs`

Se creó el script **`VisualManager`** que se encarga de:

- Elegir un color de fondo desde un arreglo (`Background Colors`).
- Aplicar un color al material del jugador (`Player Colors`).
- Ajustar la intensidad y el color de la **Directional Light**.

El script se agrega a un objeto vacío llamado `VisualManager` y se configuran las referencias desde el Inspector:

- `Main Camera` → cámara principal de la escena.
- `Main Light` → `Directional Light`.
- `Player Renderer` → objeto `Player` (Mesh Renderer del personaje).
- Listas de colores para:
  - **Background Colors** (fondo).
  - **Player Colors** (personaje).
- `Light Intensity` para controlar la intensidad de la luz.

Además, la cámara está configurada con:

- **Background Type: Solid Color** (URP), para que se vea el color asignado por el script.

---

## 🎮 Cómo probar

1. Abrir el proyecto en **Unity**.
2. Cargar la escena principal del juego (por ejemplo: `Game` o `Level1`).
3. Presionar **Play**:
   - El **fondo** cambiará de color.
   - El **personaje** cambiará de color.
   - La **luz direccional** ajustará su color e intensidad según el tema visual.

---

## 🔧 Controles básicos

- Movimiento: joystick virtual en pantalla (Android).
- Salto: botón de salto en la interfaz.

---

## 📁 Repositorio

Este repositorio es público e incluye:

- Escenas del juego.
- Scripts de movimiento, lógica de niveles y **VisualManager**.
- Prefabs y elementos necesarios para ejecutar el proyecto en Unity.


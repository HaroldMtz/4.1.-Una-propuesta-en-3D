# 4.1 Una propuesta en 3D (Unity, Android)

**Alumno:** Harold Martínez  
**Unidad:** 4 — Actividad 4.1  
**Versión de Unity:** 2022/2023/6000 (indica tu versión exacta)

## Requisitos cumplidos
- Interfaz gráfica con navegación entre escenas: `MainMenu → Game`.  
- Movimiento del personaje en **tres ejes (X/Y/Z)**: desplazamiento en X/Z y salto (Y).  
- **Colisiones** activas (`Rigidbody` + `CapsuleCollider` en Player; Mesh/Box Collider en suelo).  
- **Cámara** que sigue al personaje moviéndose solo en **X y Z** (altura fija).  

## Controles
- **Móvil:** Joystick virtual (izquierda) para mover; botón **SALTAR** (derecha).
- **PC (pruebas):** WASD para mover, **Space** para saltar.

## Estructura / Escenas
- `Assets/Scenes/MainMenu.unity`
- `Assets/Scenes/Game.unity`

## Cómo ejecutar (Editor)
1. Abrir el proyecto en Unity.
2. `File → Build Settings…` y agregar `MainMenu` (índice 0) y `Game` (índice 1).
3. Play desde `MainMenu`.

## Build Android (APK)
1. `File → Build Settings… → Android → Switch Platform`.
2. Player Settings:
   - **Scripting Backend:** IL2CPP  
   - **Target Architectures:** ARM64  
   - **Min API Level:** 26+  
   - **Graphics API:** OpenGLES3  
3. `Build` (o `Build And Run`).  
4. APK opcional en `/Releases/Proyecto3D.apk` (o enlace externo).

## Evidencias
- Ver carpeta `/Docs/`:
  - `menu.png` (pantalla de inicio)
  - `juego_movimiento.png` (movimiento X/Z)
  - `juego_salto.png` (salto en Y)
  - `camara_follow.png` (cámara siguiendo)

## Notas técnicas
- `PlayerMotor.cs` soporta: joystick/táctil, D-Pad, teclado (Legacy y New Input System), salto con **coyote time**.
- `CameraFollow.cs` mantiene **Y** fija (solo X/Z).

## Licencia
Uso académico.

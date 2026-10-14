# 2D-3D Pipeline Sample

A Unity sample project that demonstrates a simple 2D/3D scene-switching pipeline. The project keeps a shared scene-dimension state and uses it to alter movement, camera/scene behavior, and object visibility as the player toggles between 2D and 3D modes.

## Overview

This project was built to explore how a single shared state can drive a scene transition across multiple systems without tightly coupling the logic to a single object. The main pattern uses a ScriptableObject called [Assets/ScriptableObjects/SceneDimensionHandler.cs](Assets/ScriptableObjects/SceneDimensionHandler.cs) to hold the current dimension state, which is then consumed by:

- [Assets/Scripts/PlayerMovement.cs](Assets/Scripts/PlayerMovement.cs)
- [Assets/Scripts/SceneChanger.cs](Assets/Scripts/SceneChanger.cs)
- [Assets/Scripts/BuildingRenderer.cs](Assets/Scripts/BuildingRenderer.cs)

## Features

- 2D/3D toggle using a shared data asset
- Player movement logic that changes behavior between dimensions
- Building visibility updates when switching modes
- Input System-based controls
- Universal Render Pipeline (URP) project setup

## Project Structure

```text
Assets/
├── ScriptableObjects/
│   └── SceneDimensionHandler.cs
├── Scripts/
│   ├── BuildingRenderer.cs
│   ├── PlayerMovement.cs
│   └── SceneChanger.cs
├── Scene files and prefabs
├── Materials, Models, and Art assets
└── ...
Packages/
ProjectSettings/
2D-3D-Pipeline-Sample.slnx
Readme.md
```

## Requirements

- Unity 6000.3.13f1 or compatible Unity 6 version
- URP enabled by default in the project setup
- Input System package installed

## Getting Started

1. Open the project in Unity.
2. Load the main playable scene from the project window.
3. Press Play to test the dimension switch.
4. Use the in-scene input controls to move and change dimension mode.

## Controls

The project uses Unity's Input System. Typical controls include:

- Move: WASD / left stick
- Jump: Space / button input
- Toggle scene dimension: configured dimension-change action

## How the pipeline works

The dimension state is stored in a ScriptableObject so it can be shared across several gameplay systems. When the player triggers a dimension change:

1. [Assets/Scripts/SceneChanger.cs](Assets/Scripts/SceneChanger.cs) flips the current state.
2. [Assets/Scripts/PlayerMovement.cs](Assets/Scripts/PlayerMovement.cs) updates movement and rotation behavior depending on the active dimension.
3. [Assets/Scripts/BuildingRenderer.cs](Assets/Scripts/BuildingRenderer.cs) hides or re-enables buildings based on the player's position and active mode.

This creates a lightweight event-driven pattern for scene-state transitions without hardcoding everything in a single controller.

## Notes

This repository is best viewed as a learning/demo project for Unity scene-dimension transitions and shared data flow. It is not a production-ready game framework.

## License

This project does not currently declare a repository license. If you are using it for personal learning, ensure you review any third-party asset licensing in the project before publishing or distributing the project.

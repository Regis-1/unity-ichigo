# 🍓 Ichigo  (Top-Down 2D Unity demo w/ FMOD)
This is a small top-down 2D game prototype built in Unity, created as a technical demo and learning project for integrating FMOD audio middleware with gameplay systems.

The main focus of the project is audio implementation, spatial awareness, and dynamic environmental sound design, rather than gameplay complexity.

## Project Overview
The project features a simple 2D tile-based map with basic player movement and directional animations. The environment is divided into different surfaces and biome areas (cliffs & forest) that influence both movement sound and ambient audio.

The player character can move in four directions in a top-down view, supported by basic walking animations (up, down, left, and right). Footstep sounds are surface-dependent, with separate audio for grass and dirt. The footstep events plays the appropriate dynamically selected sound based on the surface the player is currently walking on.

<img width="600" height="338" alt="ichigo" src="https://github.com/user-attachments/assets/a00dd87b-1385-46cf-be5e-2fd72c60977e" />

## YouTube video
[https://youtu.be/ZurgbcZa770](https://youtu.be/ZurgbcZa770)

## 🔊 FMOD Integration Features
### Background Music
- Continuous background music loop
- Dynamically adjusted volume based on environment

### Footstep System
- Surface-aware footstep sounds
- Different audio events depending on terrain type

### Environmental Ambience
The map includes two main ambient zones:
- Forest Zone
  - Birds chirping
  - Wind rustling through leaves
- Cliff Zone
  - Ocean waves
  - Seagulls

When the player approaches an ambient zone defined in Unity using BoxCollider2D, the mix gradually shifts based on proximity. Ambient sounds become progressively more audible as the player gets closer, reaching full intensity only when fully inside the zone. At the same time, background music is subtly reduced to make space for the environmental audio. As the player moves away, the mix smoothly returns to its default balance. All transitions are driven dynamically using FMOD parameters.

## ⚠️ Setup Requirements (FMOD dependency)

This project does not include the FMOD Unity integration package in the repository.

The following folder is intentionally excluded:

`Assets/Plugins/FMOD/`

To run this project correctly, you must install FMOD for Unity manually.

Option 1 – Official FMOD website (recommended) - [FMOD official website](https://www.fmod.com/)

Option 2 – Unity Asset Store - [Unity Asset Store](https://assetstore.unity.com/)

## Credits
Sprites and tilesets used in this project come from Seliel the Shaper – Mana Seed free asset pack. ([Author's itch.io page](https://itch.io/profile/seliel-the-shaper))

Sound effects and music come from various contributors via [Pixabay's website](https://pixabay.com/)

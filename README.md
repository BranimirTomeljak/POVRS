# POVRS: Guided Missile Simulation

A simplified interactive 3D simulation of an anti-tank guided missile system, built in Unity for the *Interactive Simulation Systems* course at FER Zagreb (Dec 2022 – Jan 2023). Team of three; I wrote most of the simulation code.

## What it does

- The player aims the launcher at a target with a raycast and fires a missile that homes in on it
- The tank and launcher start from one of ten preset positions on a hand-built 3D terrain
- Enemy behaviour is chosen in the main menu: a static tank, or a moving tank with incoming fire landing around the launcher
- Fog density is set in the main menu before the run starts
- Hits trigger explosions and sound, switch to an end camera and lead to a game-over screen

## My part

Missile launching and homing (`RocketLauncher.cs`), hit and collision handling (`RocketCollision.cs`), enemy behaviour, the main menu settings, tuning (missile speed and calibration) and the final build.

## Tech

Unity 2021.3 · C#

## Running

Open the project in Unity 2021.3 LTS and start from `Assets/Scenes/MainMenuScene.unity`. The written report and presentation (in Croatian) are in `dokumentacija i prezentacija/`.

# RoboRange VR

RoboRange VR ist ein Virtual-Reality-Shooter, der mit der Unity-Engine entwickelt wurde. Der Spieler tritt in einer futuristischen Shooting Range gegen fliegende Drohnen an und sammelt innerhalb eines Zeitlimits möglichst viele Punkte.

## Projektinformationen

**Modul:** Virtual Reality und Animation

**Hochschule:** Hochschule Aalen - University of Applied Sciences

**Semester:** Sommersemester 2026

**Betreuung:** Prof. Dr. Carsten Lecon

**Projektmitglieder:**
- Lukas B
- Chris M


## Features

- VR-Interaktion mit dem XR Interaction Toolkit
- Greifbare Waffe mit Raycast-basierter Schussmechanik
- Dynamischer Target-Spawner
- Gegnerische Geschütztürme mit Lebenssystem
- Visuelles, akustisches und haptisches Feedback
- Cyberpunk-/Futuristische Umgebung mit Nightclub

---

## Technologien

- Unity 6000.3.13f1
- XR Interaction Toolkit
- Blender
- Visual Studio Code
- Git & GitHub

---

## Projektstruktur
```
├── Assets/
│   ├── Audio/                          # Soundeffekte und Hintergrundmusik
│   ├── Materials/                      # Materialien und Shader
│   ├── Models/                         # 3D-Modelle
│   ├── Prefabs/                        # Wiederverwendbare Spielobjekte
│   ├── Samples/                        # Unity/XR-Beispielinhalte
│   ├── Scenes/                         # Unity-Szenen des Projekts
│   ├── Scripts/                        # C#-Skripte
│   ├── Settings/                       # Projekteinstellungen
│   ├── TextMesh Pro/                   # TextMesh Pro Ressourcen
│   ├── UI/                             # Benutzeroberfläche (Canvas, Menüs, HUD)
│   ├── XR/                             # XR-Konfiguration
│   ├── XRI/                            # XR Interaction Toolkit Assets
│   └── InputSystem_Actions.inputactions
```

---

## Steuerung

### VR

- Pistole greifen
- Mit dem Controller zielen
- Trigger drücken um Waffe abzufeuern
- Start-, Reset-, DJ- und Exit-Button durch Beschuss aktivieren

---

## Spielablauf

1. Waffe aus dem Waffenschrank aufnehmen
2. Start-Button beschießen
3. Roboter abschießen und Punkte sammeln
4. Projektilen der Geschütztürme ausweichen
5. Spiel endet nach einer Minute oder nach Verlust aller drei Lebenspunkte
6. Reset- oder Exit-Button beschießen

---

## Voraussetzungen

- Unity 6
- OpenXR
- XR Interaction Toolkit
- Pice VR Headset (oder kompatibles OpenXR-Headset)

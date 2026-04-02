# Dungeon Slayer

A powerful, highly-optimized 2D Action RPG / Dungeon Crawler featuring smooth controls, intense 'Hit-Stop' combat natively built in Unity, and dynamic Anime-styled action mechanics.

## Features
- **Fluid Combat System**: Fast-paced melee combat with 'Hit-Stop' and screen-shake impact juice.
- **Shadow Dash**: Speed-blitz dodging mechanic that leaves behind shadow-step afterimages.
- **Awakening System**: Players can trigger a Limit-Break state increasing their combat capabilities.
- **Dynamic Loot System**: Enemies explode with scattered loot (coins, hearts, powerups) upon death.
- **Optimized Core Architecture**: Runs cleanly with zero frame-drops using an Event-driven Stats system.

---

## 🎮 How to Play

Dungeon Slayer supports both Desktop and Mobile control schemes dynamically!

### Desktop (Keyboard) Controls
- **WASD / Arrow Keys**: Move left, right, and jump.
- **Spacebar**: Jump.
- **F**: Melee Sword Attack (Triggers Hit-Stop on successful strikes).
- **C**: Fire Bow (Requires exactly 4 Power Stars).
- **Left Shift**: Shadow Dash (Leaves behind afterimages).
- **R**: Activate Awakening/Limit Break (Requires maximum Power Stars. Doubles damage output for 10 seconds).

### Mobile (Touch) Controls
- Use the **On-Screen Joystick** on the left side to move.
- Tap the **Jump Button** (Up Arrow icon) on the right side.
- Tap the **Attack / Bow Buttons** on the right side to engage in combat.
- *(Note: Thanks to input refactoring, Keyboard controls remain fully active even when the Mobile GUI is visible on screen!)*

---

## 🛠 Developer Setup

If you wish to download the source code, view the C# architecture, or modify the game yourself, follow these steps:

### 1. Required Software
Because this game utilizes specific physics integrations, you must download the correct tools from the archives.
- **Unity Editor**: Download the **Unity Hub**, then navigate to the [Unity Download Archive](https://unity.com/releases/editor/archive). Download and install **Unity 2020.1.x** (or the closely matching 2019 Long-Term Support edition). 
- **Code Editor**: Install **Visual Studio Code** (VS Code). Make sure to install the standard C# extensions for syntax highlighting.

### 2. Installation Steps
1. Clone this repository to your local machine using Git Desktop or terminal.
2. Open **Unity Hub**, click **Add Project from Disk**, and select the `dungeonslayer` root folder.
3. Unity will resolve the packages automatically. Once the project opens, go to `Edit > Preferences > External Tools` and make sure your External Script Editor is set to Visual Studio Code.
4. Double-click the `Menu.unity` scene in the `Assets/Scenes` folder.
5. Hit the **Play** button at the top to test the project!

---

## Authorship & Credits
**Authored by: Abdus Samad Raeen**  
*Lead Developer & Architect. Responsible for the full core gameplay overhaul, optimized systems, and implementation of all dynamic action abilities.*

**Special Credits & Original Implementation:**  
Some foundational assets & architecture were originally developed by [Kailius](https://github.com/Walkator/Kailius). Huge thanks for providing the base template for this project to expand upon.

*Built with Unity.*

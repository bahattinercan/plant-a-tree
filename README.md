# Plant a Tree

Plant a Tree is a 3D casual arcade game prototype developed in Unity, adapting the core timing-and-precision mechanics of Knife Hit into an environmental reforestation theme. Players tap or press the space bar to launch tree saplings upward toward a continuously rotating 3D Earth globe, aiming to embed trees into unoccupied terrain without striking previously planted trees. Each successful impact embeds the tree into the rotating sphere, shifts the terrain and water materials toward healthy green tones, increments the session score, and moves the player closer to the level target score, while hitting an already planted tree ends the round in defeat. This repository is a personal prototype project, not a maintained product, with the last substantial work committed in 2023.

## Gameplay

- **Tree projectile launch**: Launches the current tree upward with physics velocity upon receiving spacebar or left mouse click input (`Assets/Scripts/Gameplay/Knife.cs`).
- **Globe collision and sticking**: Parents the launched tree to the rotating world target upon collision, halts projectile velocity, and disables further collider triggers (`Assets/Scripts/Gameplay/Knife.cs`).
- **Tree-on-tree game over condition**: Detects collisions against previously planted trees, triggering instant round failure and playing defeat audio (`Assets/Scripts/Gameplay/Knife.cs`).
- **Dynamic tree replenishment**: Instantiates a new tree prefab at the designated spawn point after the previous tree embeds into the globe (`Assets/Scripts/Gameplay/KnifeSpawner.cs`).
- **Globe continuous rotation and directional reversal**: Rotates the Earth sphere continuously and reverses rotation direction based on level configuration or on successful hits (`Assets/Scripts/Gameplay/Wood.cs`).
- **Visual world restoration (earth color change)**: Dynamically blends the Earth mesh's ground and water material colors toward target green hues on each successful planting (`Assets/Scripts/Gameplay/EarthColorChanger.cs`).
- **Game state and score management**: Manages game start, hit events, score goals, win/loss triggers, gold rewards, and maximum level unlocking (`Assets/Scripts/Manager/GameManager.cs`).
- **ScriptableObject level design**: Configures level difficulty parameters including world speed, tree velocity, tree scale multiplier, score goal, reversal triggers, and gold rewards (`Assets/Scripts/Scriptable/LevelSO.cs`, `Assets/Scripts/Scriptable/LevelListSO.cs`).
- **Persistent game progress**: Serializes player currency (gold, crystals) and unlocked levels to local disk storage in JSON format with XOR cipher encryption support (`Assets/Scripts/DataPersistence/DataManager.cs`, `Assets/Scripts/DataPersistence/FileDataHandler.cs`, `Assets/Scripts/DataPersistence/Data/GameData.cs`).
- **Main menu panel controller**: Manages opening and closing modal overlays for level selection, shop, settings, and player inventory (`Assets/Scripts/Manager/MainMenuManager.cs`).
- **Dynamic level grid generation**: Instantiates level selection buttons programmatically based on the total levels configured in the ScriptableObject registry and the player's saved progress (`Assets/Scripts/UI/LevelPanel.cs`).
- **Settings and audio preference management**: Provides UI sliders for adjusting background music and sound effects volumes stored in player preferences (`Assets/Scripts/UI/SettingsPanel.cs`, `Assets/Scripts/Manager/PrefManager.cs`).
- **End-of-round evaluation screen**: Displays win/loss banners, star ratings, elapsed time, earned gold rewards, and action buttons for next level, restart, or returning to the main menu (`Assets/Scripts/UI/EndGamePanel.cs`).
- **Mobile advertising integration**: Configures initialization and ad request callbacks for Google Mobile Ads banner, interstitial, and rewarded video ads (`Assets/Scripts/Ad/AdBanner.cs`, `Assets/Scripts/Ad/AdInterstitial.cs`, `Assets/Scripts/Ad/AdRewarded.cs`).

## Tech Stack

- **Game Engine**: Unity `2020.3.48f1` (declared in `ProjectSettings/ProjectVersion.txt`)
- **Primary Language**: C# (.NET / Mono scripting backend)
- **UI Frameworks**: Unity UI / UGUI (`com.unity.ugui` 1.0.0), TextMesh Pro (`com.unity.textmeshpro` 3.0.6)
- **2D & Input Modules**: Unity 2D Sprite (`com.unity.2d.sprite` 1.0.0), Device Simulator (`com.unity.device-simulator` 3.0.3-preview)
- **Animation & Tweening**: Demigiant DOTween (`v1.2.675`, vendored under `Assets/Plugins/Demigiant`)
- **Monetization & Dependency Management**: Google Mobile Ads Unity Plugin with Google External Dependency Manager for Unity (`EDM4U v1.2.172`)
- **Shading & Rendering**: Toony Colors Free shader library (`Assets/Packages/JMO Assets`)

## Project Structure

| Path | Description | Type |
|---|---|---|
| `Assets/Animations/` | Animator controllers and animation clips for UI buttons, splash screen, and score counter | Own code / Data |
| `Assets/ExternalDependencyManager/` | Google External Dependency Manager for Unity (EDM4U) editor integration scripts and binaries | Third-party |
| `Assets/Fonts/` | Custom typography assets (`LilitaOne-Regular.ttf`) | Third-party / Data |
| `Assets/Materials/` | Material assets for earth terrain, water, trees, skybox, and particle visual effects | Own code / Data |
| `Assets/Models/` | 3D models and FBX assets for trees and interactive elements | Own code / Data |
| `Assets/Packages/2D Casual UI/` | Vendored 2D UI sprites, icon packs, and menu graphics | Third-party |
| `Assets/Packages/GoogleMobileAds/` | Vendored Google Mobile Ads SDK editor scripts and preprocessor utilities | Third-party |
| `Assets/Packages/JMO Assets/` | Toony Colors Free shader framework and material inspector | Third-party |
| `Assets/Packages/Low Poly Tree/` | 3D low-poly tree model assets and prefabs | Third-party |
| `Assets/Packages/LowPolyEarth/` | 3D low-poly Earth globe model, meshes, and materials | Third-party |
| `Assets/Packages/RPG Food & Drinks Pack/` | 3D item models and consumable asset prefabs | Third-party |
| `Assets/Packages/TextMesh Pro/` | TextMesh Pro font assets, shaders, and style dictionaries | Third-party |
| `Assets/Plugins/Android/` | Native Android archive plugins, dependencies, and manifest overrides | Third-party |
| `Assets/Plugins/Demigiant/` | Demigiant DOTween animation and tweening library modules | Third-party |
| `Assets/Plugins/iOS/` | Native iOS CocoaPods and Xcode framework dependencies | Third-party |
| `Assets/Prefabs/` | Gameplay and UI prefab definitions (earth, trees, buttons, dialog panels) | Own code / Data |
| `Assets/Resources/` | Runtime resource configurations, including DOTween global settings | Own code / Data |
| `Assets/Scenes/` | Unity scene files (`MainMenu.unity`, `Gameplay.unity`, `New Scene.unity`) | Own code / Data |
| `Assets/Scriptables/` | ScriptableObject data instances for levels and resource references | Own code / Data |
| `Assets/Scripts/Ad/` | Google Mobile Ads integration handlers for banner, interstitial, and rewarded ads | Own code |
| `Assets/Scripts/Data/` | Scene and data enum definitions | Own code |
| `Assets/Scripts/DataPersistence/` | JSON file data handler with XOR encryption and state persistence manager | Own code |
| `Assets/Scripts/Gameplay/` | Core mechanics scripts for projectile launching, collision, rotation, and color shifts | Own code |
| `Assets/Scripts/General/` | Utility scripts for continuous rotation and timers | Own code |
| `Assets/Scripts/Helper/` | Cross-scene data passing carrier | Own code |
| `Assets/Scripts/Manager/` | System managers for game state, scenes, audio, UI, graphics, and preferences | Own code |
| `Assets/Scripts/Scriptable/` | ScriptableObject class definitions for levels, level lists, and resource catalogs | Own code |
| `Assets/Scripts/UI/` | UI panel scripts, HUD controllers, and level select button triggers | Own code |
| `Assets/Sounds/` | Sound effect clips for hits, wins, losses, and ambient audio | Own code / Data |
| `Assets/Sprites/` | 2D UI sprites, background graphics, and HUD icons | Own code / Data |
| `Packages/` | Unity Package Manager manifest (`manifest.json`) and locked resolution dependencies | Data |
| `ProjectSettings/` | Unity engine project settings (build scenes, physics, quality, audio, tags) | Data |

## Running / Building

1. **Prerequisites**: Install [Unity Hub](https://unity.com/download) and install Unity Editor version `2020.3.48f1`. If targeting Android or iOS devices, include the corresponding build support modules during installation.
2. **Open Project**:
   - Open Unity Hub.
   - Click **Add** and select the repository root directory (`C:/Orca/gh-clones/plant-a-tree`).
   - Open the project using Unity `2020.3.48f1`. Allow Unity to resolve package dependencies and complete initial asset compilation.
3. **Entry Scene**:
   - Navigate to `Assets/Scenes/` in the Project view.
   - Open `MainMenu.unity` (configured as Scene `0` in `ProjectSettings/EditorBuildSettings.asset`).
4. **Run in Editor**:
   - Press the **Play** button at the top of the Unity Editor.
   - Use the mouse or spacebar to interact with menus and launch trees in gameplay.
5. **Building**:
   - In the Unity menu, select **File > Build Settings...**.
   - Verify that `Assets/Scenes/MainMenu.unity` (index 0) and `Assets/Scenes/Gameplay.unity` (index 1) are checked.
   - Select the target platform (e.g., PC, Mac & Linux Standalone or Android) and click **Build** or **Build and Run**.

## Repository Notes

- **Prototype Status**: This repository is a learning and experimentation prototype exploring mobile hypercasual timing mechanics and stylized visual progression. It is not an active or maintained commercial product.
- **Automated Tests**: No automated unit, integration, or playmode test suites are included in the repository.
- **Continuous Integration**: No CI/CD workflows, automated build pipelines, or GitHub Actions configurations exist (`.github/` is not present).
- **Commit History**: The git history consists of a single baseline snapshot commit (`4583763 update`, December 2023).
- **Verification Note**: Codebase details were verified through static code analysis; the project has not been compiled or executed inside this CLI environment.

## Third-Party Assets

| Folder Path | Package / Asset Name & Purpose | Licence File in Repo |
|---|---|---|
| `Assets/ExternalDependencyManager/` | Google External Dependency Manager for Unity (EDM4U v1.2.172) for mobile library resolution | None (documentation in `Editor/README.md`) |
| `Assets/Packages/2D Casual UI/` | 2D Casual UI graphics pack providing buttons, icons, and interface frames | None (readme in `readme.rtf`) |
| `Assets/Packages/GoogleMobileAds/` | Google Mobile Ads Unity plugin for ad delivery and manifest processing | None |
| `Assets/Packages/JMO Assets/` | Toony Colors Free stylized shader library by Jean Moreno (JMO) | None (readme in `Toony Colors/!ToonyColors Readme.txt`) |
| `Assets/Packages/Low Poly Tree/` | 3D low-poly tree models and foliage meshes | None |
| `Assets/Packages/LowPolyEarth/` | 3D low-poly Earth globe model, materials, and textures | None (readme in `Readme_v1.pdf`) |
| `Assets/Packages/RPG Food & Drinks Pack/` | Low-poly 3D food and drink item models | None |
| `Assets/Packages/TextMesh Pro/` | TextMesh Pro default font assets and material presets | None |
| `Assets/Plugins/Demigiant/` | DOTween animation tweening library for Unity | None (readme in `DOTween/readme.txt`) |
| `Assets/Plugins/Android/` | Native Android Google Mobile Ads libraries and build configurations | None |
| `Assets/Plugins/iOS/` | Native iOS Google Mobile Ads SDK dependencies and pod configurations | None |

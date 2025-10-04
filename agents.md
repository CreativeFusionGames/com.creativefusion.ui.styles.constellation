# agents.md

## 1. Metadata Table
| Field | Value |
| --- | --- |
| name | CreativeFusion UI Styles � CosmicElements |
| description | UI Toolkit style pack delivering CosmicElements-themed layouts, styles, and screen mappings for CreativeFusion navigation flows. |
| category | Unity UI Toolkit / UX Styling |
| lastUpdated | 2025-04-10 |

## 2. Project Title & Overview
CosmicElements UI Styles provides a complete visual skin for the CreativeFusion UI navigation stack. It supplies themed `UIScreen` derivatives, UXML/USS assets, list templates, and a ready-to-use `UIScreenConfigSet` so product teams can plug the CosmicElements look into existing logic screens without touching gameplay code. The pack targets menu-driven experiences and any scenario that needs a polished sci-fi inspired presentation layer.

## 3. Project Structure
- `package.json` � Unity package metadata and dependency declarations.
- `Runtime/Creativefusion.Ui.Styles.CosmicElements.asmdef` � Assembly definition referencing UI Core and Screens.
- `Runtime/Internal` � Resource path constants and layout loading helpers.
- `Runtime/CosmicElementsStyle*.cs` � Public runtime API (config access, constants).
- `Runtime/Screens` � CosmicElements-themed subclasses for MainMenu, Start, LevelSelect, and Shop screens.
- `Runtime/Resources/CosmicElements/Uxml` � Layouts and reusable templates.
- `Runtime/Resources/CosmicElements/Uss` � Style sheets per feature area.
- `Runtime/Resources/CosmicElements/Configs` � Packaged `CosmicElementsUIScreenConfigSet.asset` resource.


## 4. Development Guidelines
- Follow clean-code constraints: =200 lines per class, =25 lines per method, =2 nesting levels, cyclomatic complexity =8.
- Keep styling data-driven: load UXML/USS via `CosmicElementsScreenUtility` rather than hard-coded inline elements.
- Only extend logic by subclassing the shared screen implementations; do not modify `com.creativefusion.ui.screens`.
- Prefer resource path helpers (`CosmicElementsResourcePaths`) to avoid brittle strings.
- Update `CosmicElementsUIScreenConfigSet.asset` and `CosmicElementsStyle.ResetCache()` whenever new screens are added.
- Maintain XML documentation on every public API surface for discoverability.

## 5. Environment Setup
1. Install Unity 2022.3 LTS or newer.
2. Add required packages: `com.creativefusion.ui.core` and `com.creativefusion.ui.screens` (already declared in `package.json`).
3. Ensure the scene contains a `UIDocument` root; navigation operates on its `rootVisualElement`.
4. Place this package under `Packages/com.creativefusion.ui.styles.cosmicelements/` or add via Git URL.
5. (Optional) Import the `WebsiteMockups` HTML into your design tool for visual reference; no runtime impact.

## 6. Core Feature Implementation
- **Layout Loader** (`CosmicElementsScreenUtility`): Caches `VisualTreeAsset`/`StyleSheet`, injects layouts into `UIScreen` roots, and exposes template factories for list views.
- **Screen Subclasses**: Each CosmicElements screen overrides `OnInitialize()` to call `CosmicElementsScreenUtility.ApplyLayout()` and configure binders before delegating to base logic.
- **Config Set Access** (`CosmicElementsStyle` + asset): Wraps the serialized `CosmicElementsUIScreenConfigSet.asset` so navigation services can be configured with one call.

```csharp
var navigation = new UINavigationService(document.rootVisualElement);
navigation.Configure(CosmicElementsStyle.GetConfigSet());
navigation.Push(CosmicElementsScreenIds.MainMenu);
```

- **Templates**: Level, category, and item templates expose named labels (`level-title`, `item-cost`, etc.) used by the binders inside the themed screen subclasses.

## 8. Deployment Guide
- Commit package files (including `.meta`) to your VCS inside `Packages/com.creativefusion.ui.styles.cosmicelements`.
- Publish to a scoped Git registry or mirrored repository; consumers add the Git URL to the Unity Package Manager or copy into their project `Packages` directory.
- When versioning, update `package.json` semver and tag the repository to create a reproducible release.

## 9. Performance Optimization
- Layouts and templates are cached in-memory to avoid repeated `Resources.Load` calls.
- List views use lightweight binders and rely on UI Toolkit virtualization (`DynamicHeight`) to keep scrolling smooth.
- Avoid heavy runtime modifications; instead adjust UXML/USS assets so UI Toolkit can batch style recalculations.
- Use `CosmicElementsStyle.ResetCache()` if you hot-swap resources during development; avoid calling it every frame.

## 10. Security Considerations
- Package stores no player data; input validation is handled by consumer logic.
- Resources are read-only assets; no runtime file writes occur.
- When adding new bindings, sanitize text displayed from external sources to prevent markup injection if you later enable Rich Text.

## 11. Monitoring & Logging
- Runtime helpers throw descriptive exceptions for missing resources, making misconfiguration visible in standard Unity logs.
- Integrate with `com.creativefusion.debug` if you need live diagnostics; hook into screen events (`ScreenFocused`, etc.) exposed by `IUINavigationService`.
- Use Unity Profiler/UIToolkit Event Debugger to trace layout performance during iteration.

## 12. Common Issues & Solutions
- **Missing visuals**: Ensure the `CosmicElementsUIScreenConfigSet.asset` remains in `Resources/CosmicElements/Configs`; calls to `CosmicElementsStyle.GetConfigSet()` depend on this path.
- **Null references when binding**: Element names in custom UXML must stay aligned with the constants used by `com.creativefusion.ui.screens` (e.g., `start-button`, `level-list`).
- **Duplicate styles**: If you add additional USS files, remember to register them via code before calling `base.OnInitialize()`.
- **Navigation not showing screens**: Confirm the navigation root `VisualElement` is empty and that the config set contains every requested screen id.

## 13. Reference Resources
- Unity UI Toolkit manual & samples (https://docs.unity3d.com/Manual/uitk.html).
- CreativeFusion Core UI documentation in `com.creativefusion.ui.core/README.md`.
- CreativeFusion Screen logic guidance in `com.creativefusion.ui.screens/README.md`.

## 14. Changelog
- **1.0.0 (2025-04-10)** � Initial release with CosmicElements styling for Main Menu, Start, Level Select, and Shop screens plus navigation config asset.

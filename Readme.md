# CreativeFusion UI Styles �CosmicElementsn

CosmicElements is the first CreativeFusion UI Toolkit style pack. It ships production ready UXML/USS layouts, themed list templates, and a `UIScreenConfigSet` that maps the shared logic screens to CosmicElements visual implementations.

## Highlights
- CosmicElements look & feel for main menu, start, level select, and shop flows.
- Re-usable list templates with adaptive bindings for levels, categories, and items.
- `CosmicElementsUIScreenConfigSet.asset` and helper API to plug the theme into the navigation service in one line.
- Lightweight runtime code that keeps logic inside `com.creativefusion.ui.screens` untouched while providing themed subclasses.
- Resources-based delivery so layouts and styles are easy to swap or extend at runtime.

## Package Contents
- `Runtime/Screens/CosmicElements*Screen.cs` � themed derivatives of the CreativeFusion screen logic classes.
- `Runtime/CosmicElementsStyle.cs` � convenience accessors for the packaged `UIScreenConfigSet`.
- `Runtime/Internal` � resource path helpers and layout utilities.
- `Runtime/Resources/CosmicElements` � UXML, USS, templates, and theCosmicElementsonUIScreenConfigSet.asset` resource.
- `Runtime/ExampleRuntimeFile.cs` � bootstrap example that wires the navigation service to thCosmicElementson theme.

## Unity Requirements
- Unity **2022.3 LTS** or newer.
- UI Toolkit runtime enabled (default in 2022+).
- Dependencies declared in `package.json`: `com.creativefusion.ui.core` and `com.creativefusion.ui.screens` (both v1.0.0).

## Getting Started
1. Install the package inside `Packages/com.creativefusion.ui.styles.cosmicelements` (Git or local disk).
2. Add a `UIDocument` to your scene and assign a root `VisualElement` container.
3. Configure the navigation service with the CosmicElements config set:

```csharp
using Creativefusion.Ui.Core;
using Creativefusion.Ui.Styles.CosmicElements;

public sealed class CosmicElementsEntry : MonoBehaviour
{
    [SerializeField] private UIDocument document;
    private IUINavigationService navigation;

    private void Awake()
    {
        navigation = new UINavigationService(document.rootVisualElement);
        navigation.Configure(CosmicElementsStyle.GetConfigSet());
        navigation.Push(CosmicElementsScreenIds.MainMenu);
    }
}
```

4. If you prefer authoring overrides, duplicate the packaged `CosmicElementsUIScreenConfigSet.asset`, edit the mappings, and assign the asset to `CosmicElementsStyleBootstrap` or your own bootstrapper.

## Screen Identifiers
| Screen | Identifier | Screen Class |
| --- | --- | --- |
| Main Menu | `main-menu` | `CosmicElementsMainMenuScreen` |
| Start | `start` | `CosmicElementsStartScreen` |
| Level Select | `level-select` | `CosmicElementsLevelSelectScreen` |
| Shop | `shop` | `CosmicElementsShopScreen` |

Use the constants in `CosmicElementsScreenIds` for navigation calls.

## Layout & Styling
- Layouts live in `Resources/CosmicElements/Uxml/*.uxml`. Each top-level element includes the `cosmicelements-screen` class, while nested frames add screen-specific classes.
- Shared styling resides in `Resources/CosmicElements/Uss/base.uss`; additional files scope tweaks for forms, lists, and each screen.
- List templates (level, category, item) are located under `Resources/CosmicElements/Uxml/Templates` and are wired automatically by the runtime classes.

## Extending the Theme
- Add new screens by creating a `CosmicElements` subclass of the relevant logic screen, calling `CosmicElementsScreenUtility.ApplyLayout`, and updating the config asset.
- To refresh cached data after changing the packaged asset at runtime, call `CosmicElementsStyle.ResetCache()`.
- Styles can be swapped or augmented by adding new USS files and referencing them through your screen subclass.

## Support & Maintenance
- Errors loading resources throw descriptive `InvalidOperationException` messages to help catch missing assets early.
- All visual assets are stored under Resources for compatibility with addressable loading or asset bundles if you later migrate away from Resources.

using CreativeFusion.Ui.Screens.Screens;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;

namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
    /// <summary>
    /// CosmicElements-themed implementation of the <see cref="MainMenuScreen"/> visuals.
    /// </summary>
    public sealed class CosmicElementsMainMenuScreen : MainMenuScreen
    {
        private static readonly string[] StylePaths =
        {
            CosmicElementsResourcePaths.Style("base"),
            CosmicElementsResourcePaths.Style("main-menu")
        };

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("MainMenu"), StylePaths);
            base.OnInitialize();
        }
    }
}

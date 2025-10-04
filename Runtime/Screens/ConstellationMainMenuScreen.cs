using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.Constellation.Internal;

namespace Creativefusion.Ui.Styles.Constellation.Screens
{
    /// <summary>
    /// Constellation-themed implementation of the <see cref="MainMenuScreen"/> visuals.
    /// </summary>
    public sealed class ConstellationMainMenuScreen : MainMenuScreen
    {
        private static readonly string[] StylePaths =
        {
            ConstellationResourcePaths.Style("base"),
            ConstellationResourcePaths.Style("main-menu")
        };

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            ConstellationScreenUtility.ApplyLayout(this, ConstellationResourcePaths.Layout("MainMenu"), StylePaths);
            base.OnInitialize();
        }
    }
}

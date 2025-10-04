using CreativeFusion.Ui.Screens.Screens;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;

namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
    /// <summary>
    /// CosmicElements-themed implementation of the <see cref="StartScreen"/> visuals.
    /// </summary>
    public sealed class CosmicElementsStartScreen : StartScreen
    {
        private static readonly string[] StylePaths =
        {
            CosmicElementsResourcePaths.Style("base"),
            CosmicElementsResourcePaths.Style("forms"),
            CosmicElementsResourcePaths.Style("start")
        };

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("Start"), StylePaths);
            base.OnInitialize();
        }
    }
}

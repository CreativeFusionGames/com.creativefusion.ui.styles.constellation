using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.Constellation.Internal;

namespace Creativefusion.Ui.Styles.Constellation.Screens
{
    /// <summary>
    /// Constellation-themed implementation of the <see cref="StartScreen"/> visuals.
    /// </summary>
    public sealed class ConstellationStartScreen : StartScreen
    {
        private static readonly string[] StylePaths =
        {
            ConstellationResourcePaths.Style("base"),
            ConstellationResourcePaths.Style("forms"),
            ConstellationResourcePaths.Style("start")
        };

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            ConstellationScreenUtility.ApplyLayout(this, ConstellationResourcePaths.Layout("Start"), StylePaths);
            base.OnInitialize();
        }
    }
}

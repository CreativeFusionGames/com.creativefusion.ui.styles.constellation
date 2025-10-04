using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;


namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
[UIScreen(CosmicElementsScreenIds.SplashLoading)]
public class CosmicElementsSplashLoadingScreen : UIScreen
{
private static readonly string[] StylePaths =
{
CosmicElementsResourcePaths.Style("base"),
CosmicElementsResourcePaths.Style("splash-loading"),
};


protected override void OnInitialize()
{
CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("SplashLoading"), StylePaths);
}
}
}
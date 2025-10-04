using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;


namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
[UIScreen(CosmicElementsScreenIds.MainMenu)]
public class CosmicElementsMainMenuScreen : UIScreen
{
private static readonly string[] StylePaths =
{
CosmicElementsResourcePaths.Style("base"),
CosmicElementsResourcePaths.Style("main-menu"),
};


protected override void OnInitialize()
{
CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("MainMenu"), StylePaths);
}
}
}
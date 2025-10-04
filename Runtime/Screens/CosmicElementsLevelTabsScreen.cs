

using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;


namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
[UIScreen(CosmicElementsScreenIds.LevelTabs)]
public class CosmicElementsLevelTabsScreen : UIScreen
{
private static readonly string[] StylePaths =
{
CosmicElementsResourcePaths.Style("base"),
CosmicElementsResourcePaths.Style("level-tabs"),
};


protected override void OnInitialize()
{
CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("LevelTabs"), StylePaths);
}
}
}
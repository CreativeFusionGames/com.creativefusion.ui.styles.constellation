using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;


namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
public class CosmicElementsLevelGridScreen : UIScreen
{
private static readonly string[] StylePaths =
{
CosmicElementsResourcePaths.Style("base"),
CosmicElementsResourcePaths.Style("level-grid"),
};


protected override void OnInitialize()
{
CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("LevelGrid"), StylePaths);
}
}
}
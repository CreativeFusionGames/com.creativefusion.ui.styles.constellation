

using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;
using UnityEngine.UIElements;


namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
public class CosmicElementsShopScreen : UIScreen
{
private static readonly string[] StylePaths =
{
CosmicElementsResourcePaths.Style("base"),
CosmicElementsResourcePaths.Style("shop"),
};


protected override void OnInitialize()
{
CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("Shop"), StylePaths);
}
}
}
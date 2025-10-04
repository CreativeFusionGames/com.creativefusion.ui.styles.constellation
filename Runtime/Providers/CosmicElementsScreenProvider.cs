using System.Collections.Generic;
using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Screens;

namespace CreativeFusion.Ui.Styles.CosmicElements.Providers
{
    public sealed class CosmicElementsScreenProvider : IScreenProvider
    {
        public IEnumerable<UIScreenConfig> GetConfigs()
        {
            yield return UIScreenConfig.For(typeof(CosmicElementsMainMenuScreen), CosmicElementsScreenIds.MainMenu);
            yield return UIScreenConfig.For(typeof(CosmicElementsLevelGridScreen), CosmicElementsScreenIds.LevelGrid);
            yield return UIScreenConfig.For(typeof(CosmicElementsLevelPathScreen), CosmicElementsScreenIds.LevelPath);
            yield return UIScreenConfig.For(typeof(CosmicElementsLevelTabsScreen), CosmicElementsScreenIds.LevelTabs);
            yield return UIScreenConfig.For(typeof(CosmicElementsShopScreen), CosmicElementsScreenIds.Shop);
            yield return UIScreenConfig.For(typeof(CosmicElementsSplashLoadingScreen), CosmicElementsScreenIds.SplashLoading);
        }
    }
}

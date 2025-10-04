using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.CosmicElements.Internal;
using UnityEngine.UIElements;

namespace Creativefusion.Ui.Styles.CosmicElements.Screens
{
    /// <summary>
    /// CosmicElements-themed implementation of the <see cref="ShopScreen"/> visuals.
    /// </summary>
    public sealed class CosmicElementsShopScreen : ShopScreen
    {
        private static readonly string[] StylePaths =
        {
            CosmicElementsResourcePaths.Style("base"),
            CosmicElementsResourcePaths.Style("lists"),
            CosmicElementsResourcePaths.Style("shop")
        };

        private static readonly string CategoryTemplatePath = CosmicElementsResourcePaths.Template("ShopCategory");
        private static readonly string ItemTemplatePath = CosmicElementsResourcePaths.Template("ShopItem");

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("Shop"), StylePaths);
            ConfigureTemplates(
                CosmicElementsScreenUtility.CreateTemplateFactory(CategoryTemplatePath),
                BindCategory,
                CosmicElementsScreenUtility.CreateTemplateFactory(ItemTemplatePath),
                BindItem);
            base.OnInitialize();
        }

        private static void BindCategory(VisualElement element, ShopCategoryViewModel category)
        {
            if (element == null)
            {
                return;
            }

            var title = element.Q<Label>("category-title");
            if (title != null)
            {
                title.text = category.DisplayName;
            }
        }

        private static void BindItem(VisualElement element, ShopItemViewModel item)
        {
            if (element == null)
            {
                return;
            }

            var title = element.Q<Label>("item-title");
            if (title != null)
            {
                title.text = item.DisplayName;
            }

            var cost = element.Q<Label>("item-cost");
            if (cost != null)
            {
                cost.text = item.Cost;
            }

            var status = element.Q<Label>("item-status");
            if (status != null)
            {
                status.text = item.IsOwned ? "Owned" : item.IsAffordable ? "Available" : "Insufficient Funds";
            }

            element.EnableInClassList("is-owned", item.IsOwned);
            element.EnableInClassList("is-locked", !item.IsAffordable && !item.IsOwned);
        }
    }
}

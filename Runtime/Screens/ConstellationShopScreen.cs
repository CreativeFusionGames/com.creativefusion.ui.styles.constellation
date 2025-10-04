using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.Constellation.Internal;
using UnityEngine.UIElements;

namespace Creativefusion.Ui.Styles.Constellation.Screens
{
    /// <summary>
    /// Constellation-themed implementation of the <see cref="ShopScreen"/> visuals.
    /// </summary>
    public sealed class ConstellationShopScreen : ShopScreen
    {
        private static readonly string[] StylePaths =
        {
            ConstellationResourcePaths.Style("base"),
            ConstellationResourcePaths.Style("lists"),
            ConstellationResourcePaths.Style("shop")
        };

        private static readonly string CategoryTemplatePath = ConstellationResourcePaths.Template("ShopCategory");
        private static readonly string ItemTemplatePath = ConstellationResourcePaths.Template("ShopItem");

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            ConstellationScreenUtility.ApplyLayout(this, ConstellationResourcePaths.Layout("Shop"), StylePaths);
            ConfigureTemplates(
                ConstellationScreenUtility.CreateTemplateFactory(CategoryTemplatePath),
                BindCategory,
                ConstellationScreenUtility.CreateTemplateFactory(ItemTemplatePath),
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

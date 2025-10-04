using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.CosmicElements.Internal;
using UnityEngine.UIElements;

namespace Creativefusion.Ui.Styles.CosmicElements.Screens
{
    /// <summary>
    /// CosmicElements-themed implementation of the <see cref="LevelSelectScreen"/> visuals.
    /// </summary>
    public sealed class CosmicElementsLevelSelectScreen : LevelSelectScreen
    {
        private static readonly string[] StylePaths =
        {
            CosmicElementsResourcePaths.Style("base"),
            CosmicElementsResourcePaths.Style("lists"),
            CosmicElementsResourcePaths.Style("level-select")
        };

        private static readonly string LevelTemplatePath = CosmicElementsResourcePaths.Template("LevelSelectItem");

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("LevelSelect"), StylePaths);
            ConfigureItemTemplate(
                CosmicElementsScreenUtility.CreateTemplateFactory(LevelTemplatePath),
                BindLevelItem);
            base.OnInitialize();
        }

        private static void BindLevelItem(VisualElement element, LevelEntryViewModel level)
        {
            if (element == null)
            {
                return;
            }

            var title = element.Q<Label>("level-title");
            if (title != null)
            {
                title.text = level.DisplayName;
            }

            var status = element.Q<Label>("level-status");
            if (status != null)
            {
                status.text = level.IsLocked ? "Locked" : "Ready";
            }

            element.EnableInClassList("is-locked", level.IsLocked);
        }
    }
}

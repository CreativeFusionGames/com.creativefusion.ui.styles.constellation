using CreativeFusion.Ui.Screens.Screens;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;
using UnityEngine.UIElements;

namespace CreativeFusion.Ui.Styles.CosmicElements.Screens
{
    /// <summary>
    /// CosmicElements-themed implementation of the <see cref="LevelSelectScreen"/> visuals.
    /// </summary>
    public class CosmicElementsLevelSelectScreen : LevelSelectScreen
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
            base.OnInitialize();
            CosmicElementsScreenUtility.ApplyLayout(this, CosmicElementsResourcePaths.Layout("LevelSelect"), StylePaths);
            ConfigureItemTemplate(
                CosmicElementsScreenUtility.CreateTemplateFactory(LevelTemplatePath),
                BindLevelItem);
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

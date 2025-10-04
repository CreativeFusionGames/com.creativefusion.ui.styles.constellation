using Creativefusion.Ui.Screens.Screens;
using Creativefusion.Ui.Styles.Constellation.Internal;
using UnityEngine.UIElements;

namespace Creativefusion.Ui.Styles.Constellation.Screens
{
    /// <summary>
    /// Constellation-themed implementation of the <see cref="LevelSelectScreen"/> visuals.
    /// </summary>
    public sealed class ConstellationLevelSelectScreen : LevelSelectScreen
    {
        private static readonly string[] StylePaths =
        {
            ConstellationResourcePaths.Style("base"),
            ConstellationResourcePaths.Style("lists"),
            ConstellationResourcePaths.Style("level-select")
        };

        private static readonly string LevelTemplatePath = ConstellationResourcePaths.Template("LevelSelectItem");

        /// <inheritdoc />
        protected override void OnInitialize()
        {
            ConstellationScreenUtility.ApplyLayout(this, ConstellationResourcePaths.Layout("LevelSelect"), StylePaths);
            ConfigureItemTemplate(
                ConstellationScreenUtility.CreateTemplateFactory(LevelTemplatePath),
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

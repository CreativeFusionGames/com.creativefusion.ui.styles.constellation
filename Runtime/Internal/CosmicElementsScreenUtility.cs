using System;
using System.Collections.Generic;
using CreativeFusion.Ui.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace CreativeFusion.Ui.Styles.CosmicElements.Internal
{
    /// <summary>
    /// Provides helpers for loading and applying themed UI Toolkit assets.
    /// </summary>
    public static class CosmicElementsScreenUtility
    {
        private static readonly Dictionary<string, VisualTreeAsset> LayoutCache = new(StringComparer.Ordinal);
        private static readonly Dictionary<string, VisualTreeAsset> TemplateCache = new(StringComparer.Ordinal);
        private static readonly Dictionary<string, StyleSheet> StyleCache = new(StringComparer.Ordinal);

        /// <summary>
        /// Replaces the visual content of a screen with the specified layout and styles.
        /// </summary>
        /// <param name="screen">The screen to populate.</param>
        /// <param name="layoutPath">The Resources path of the layout without file extension.</param>
        /// <param name="styleSheetPaths">Optional style sheet resource paths.</param>
        public static void ApplyLayout(UIScreen screen, string layoutPath, params string[] styleSheetPaths)
        {
            if (screen == null)
            {
                throw new ArgumentNullException(nameof(screen));
            }

            var layout = LoadLayout(layoutPath);
            screen.Clear();
            screen.name = layout.name + "-screen";


// CosmicElementsScreenUtility.ApplyLayout(...)
screen.style.flexGrow = 1f;
screen.style.width  = Length.Percent(100);
screen.style.height = Length.Percent(100);

var container = layout.Instantiate();
container.name = layout.name + "-container";
container.style.flexGrow = 1f;
container.style.width  = Length.Percent(100);
container.style.height = Length.Percent(100);

screen.Add(container);


            screen.AddToClassList("cosmicelements-screen-root");

            if (styleSheetPaths == null || styleSheetPaths.Length == 0)
            {
                return;
            }

            foreach (var path in styleSheetPaths)
            {
                if (string.IsNullOrWhiteSpace(path))
                {
                    continue;
                }

                var styleSheet = LoadStyle(path);



                if (!screen.styleSheets.Contains(styleSheet))
                {
                    screen.styleSheets.Add(styleSheet);
                }
                else {
                    Debug.LogWarning($"[CosmicElements] Style not found at '{path}'. Skipping.");

                }
            }
        }

        /// <summary>
        /// Creates a factory suitable for UI Toolkit list views using a visual template asset.
        /// </summary>
        /// <param name="templatePath">The Resources path of the template without file extension.</param>
        /// <returns>A factory that instantiates the template when invoked.</returns>
        public static Func<VisualElement> CreateTemplateFactory(string templatePath)
        {
            var template = LoadTemplate(templatePath);
            return () =>
            {
                var instance = template.Instantiate();
                instance.name = template.name + "-item";
                return instance;
            };
        }

        /// <summary>
        /// Loads a <see cref="VisualTreeAsset"/> representing a screen layout.
        /// </summary>
        /// <param name="path">The Resources path without extension.</param>
        private static VisualTreeAsset LoadLayout(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Layout path cannot be null or whitespace.", nameof(path));
            }

            if (!LayoutCache.TryGetValue(path, out var asset))
            {
                asset = LoadResource<VisualTreeAsset>(path);
                LayoutCache[path] = asset;
            }

            return asset;
        }

        private static VisualTreeAsset LoadTemplate(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Template path cannot be null or whitespace.", nameof(path));
            }

            if (!TemplateCache.TryGetValue(path, out var asset))
            {
                asset = LoadResource<VisualTreeAsset>(path);
                TemplateCache[path] = asset;
            }

            return asset;
        }

        private static StyleSheet LoadStyle(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Style path cannot be null or whitespace.", nameof(path));
            }

            if (!StyleCache.TryGetValue(path, out var asset))
            {
                asset = LoadResource<StyleSheet>(path);
                StyleCache[path] = asset;
            }

            return asset;
        }

        private static T LoadResource<T>(string path)
            where T : UnityEngine.Object
        {
            var asset = UnityEngine.Resources.Load<T>(path);
            if (asset == null)
            {
                throw new InvalidOperationException($"CosmicElements style resource not found at '{path}'.");
            }

            return asset;
        }
    }
}

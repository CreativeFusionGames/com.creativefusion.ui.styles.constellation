using System;

namespace Creativefusion.Ui.Styles.Constellation.Internal
{
    /// <summary>
    /// Centralizes resource path construction for the Constellation UI theme.
    /// </summary>
    internal static class ConstellationResourcePaths
    {
        private const string Root = "Constellation";
        private const string LayoutRoot = Root + "/Uxml";
        private const string TemplateRoot = LayoutRoot + "/Templates";
        private const string StyleRoot = Root + "/Uss";
        private const string ConfigRoot = Root + "/Configs";

        /// <summary>
        /// Gets the resource path for a screen layout without file extension.
        /// </summary>
        /// <param name="name">The UXML filename without extension.</param>
        public static string Layout(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Layout name cannot be null or whitespace.", nameof(name));
            }

            return LayoutRoot + "/" + name;
        }

        /// <summary>
        /// Gets the resource path for an item template without file extension.
        /// </summary>
        /// <param name="name">The template filename without extension.</param>
        public static string Template(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Template name cannot be null or whitespace.", nameof(name));
            }

            return TemplateRoot + "/" + name;
        }

        /// <summary>
        /// Gets the resource path for a style sheet without file extension.
        /// </summary>
        /// <param name="name">The USS filename without extension.</param>
        public static string Style(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Style name cannot be null or whitespace.", nameof(name));
            }

            return StyleRoot + "/" + name;
        }

        /// <summary>
        /// Gets the resource path for a configuration asset without file extension.
        /// </summary>
        /// <param name="name">The asset filename without extension.</param>
        public static string Config(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Config name cannot be null or whitespace.", nameof(name));
            }

            return ConfigRoot + "/" + name;
        }
    }
}

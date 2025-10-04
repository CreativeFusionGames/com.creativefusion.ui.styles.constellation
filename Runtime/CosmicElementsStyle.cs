using System;
using CreativeFusion.Ui.Core;
using CreativeFusion.Ui.Styles.CosmicElements.Internal;
using CreativeFusion.Ui.Styles.CosmicElements.Resources;
using UnityEngine;

namespace CreativeFusion.Ui.Styles.CosmicElements
{
    /// <summary>
    /// Provides runtime helpers for accessing CosmicElements style assets.
    /// </summary>
    public static class CosmicElementsStyle
    {
        private static UIScreenConfigSet? _cachedConfig;

        /// <summary>
        /// Loads the CosmicElements <see cref="UIScreenConfigSet"/> from Resources and caches the result.
        /// </summary>
        /// <returns>The configured <see cref="UIScreenConfigSet"/> for this style pack.</returns>
        public static UIScreenConfigSet GetConfigSet()
        {
            if (_cachedConfig != null)
            {
                return _cachedConfig;
            }

            var asset = UnityEngine.Resources.Load<CosmicElementsUIScreenConfigSetAsset>(CosmicElementsResourcePaths.Config("CosmicElementsUIScreenConfigSet"));
            if (asset == null)
            {
                throw new InvalidOperationException("CosmicElements UIScreenConfigSet asset could not be located in Resources.");
            }

            _cachedConfig = asset.Build();
            return _cachedConfig;
        }

        /// <summary>
        /// Clears cached resources so that a fresh instance can be created.
        /// </summary>
        public static void ResetCache()
        {
            _cachedConfig = null;
        }
    }
}

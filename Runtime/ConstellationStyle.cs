using System;
using Creativefusion.Ui.Core;
using Creativefusion.Ui.Styles.Constellation.Internal;
using UnityEngine;

namespace Creativefusion.Ui.Styles.Constellation
{
    /// <summary>
    /// Provides runtime helpers for accessing Constellation style assets.
    /// </summary>
    public static class ConstellationStyle
    {
        private static UIScreenConfigSet? _cachedConfig;

        /// <summary>
        /// Loads the Constellation <see cref="UIScreenConfigSet"/> from Resources and caches the result.
        /// </summary>
        /// <returns>The configured <see cref="UIScreenConfigSet"/> for this style pack.</returns>
        public static UIScreenConfigSet GetConfigSet()
        {
            if (_cachedConfig != null)
            {
                return _cachedConfig;
            }

            var asset = Resources.Load<ConstellationUIScreenConfigSetAsset>(ConstellationResourcePaths.Config("ConstellationUIScreenConfigSet"));
            if (asset == null)
            {
                throw new InvalidOperationException("Constellation UIScreenConfigSet asset could not be located in Resources.");
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

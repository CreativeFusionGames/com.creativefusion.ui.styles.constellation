#nullable enable
using System;
using System.Collections.Generic;
using CreativeFusion.Ui.Core;
using UnityEngine;

namespace CreativeFusion.Ui.Styles.CosmicElements.Resources
{
    /// <summary>
    /// Scriptable object representation of a <see cref="UIScreenConfigSet"/> for the CosmicElements theme.
    /// </summary>
    [CreateAssetMenu(
        fileName = "CosmicElementsUIScreenConfigSet",
        menuName = "CreativeFusion/UI/CosmicElements/Screen Config Set" )]
    public sealed class CosmicElementsUIScreenConfigSetAsset : ScriptableObject
    {
        [SerializeField]
        private ScreenEntry[] _screens = Array.Empty<ScreenEntry>();

        /// <summary>
        /// Builds an immutable <see cref="UIScreenConfigSet"/> from the serialized screen entries.
        /// </summary>
        /// <returns>A configured <see cref="UIScreenConfigSet"/>.</returns>
        public UIScreenConfigSet Build()
        {
            var builder = UIScreenConfigSet.CreateBuilder();
            foreach (var entry in _screens)
            {
                builder.Add(entry.ToConfig());
            }

            return builder.Build();
        }

        /// <summary>
        /// Enumerates the configured screen identifiers for validation and tooling.
        /// </summary>
        public IReadOnlyList<string> GetScreenIds()
        {
            var ids = new List<string>(_screens.Length);
            foreach (var entry in _screens)
            {
                if (!string.IsNullOrWhiteSpace(entry.ScreenId))
                {
                    ids.Add(entry.ScreenId);
                }
            }

            return ids;
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            foreach (var entry in _screens)
            {
                if (string.IsNullOrWhiteSpace(entry.ScreenId))
                {
                    Debug.LogWarning($"CosmicElements screen entry on asset '{name}' has an empty screen id.", this);
                }
                else if (entry.TryResolveType() == null)
                {
                    Debug.LogWarning($"Unable to resolve screen type '{entry.ScreenTypeName}' for '{entry.ScreenId}'.", this);
                }
            }
        }
#endif

        [Serializable]
        private struct ScreenEntry
        {
            [SerializeField]
            private string _screenId;

            [SerializeField]
            private string _screenTypeName;

            [SerializeField]
            private bool _cacheInstance;

            public string ScreenId => _screenId;

            public string ScreenTypeName => _screenTypeName;

            public UIScreenConfig ToConfig()
            {
                if (string.IsNullOrWhiteSpace(_screenId))
                {
                    throw new InvalidOperationException("Screen id cannot be null or whitespace.");
                }

                var type = TryResolveType();
                if (type == null)
                {
                    throw new InvalidOperationException($"Cannot resolve screen type '{_screenTypeName}' for '{_screenId}'.");
                }

                return new UIScreenConfig(_screenId, type, _cacheInstance);
            }

            public Type? TryResolveType()
            {
                return string.IsNullOrWhiteSpace(_screenTypeName) ? null : Type.GetType(_screenTypeName);
            }
        }
    }
}

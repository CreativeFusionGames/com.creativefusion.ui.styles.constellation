using System;
using Creativefusion.Ui.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Creativefusion.Ui.Styles.Constellation
{
    /// <summary>
    /// Example MonoBehaviour that wires the Constellation style pack into the navigation service.
    /// </summary>
    public sealed class ConstellationStyleBootstrap : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("UIDocument that hosts the navigation root.")]
        private UIDocument? _uiDocument;

        [SerializeField]
        [Tooltip("Optional override of the packaged screen configuration.")]
        private ConstellationUIScreenConfigSetAsset? _screenConfig;

        private IUINavigationService? _navigation;

        private void Awake()
        {
            if (_uiDocument == null)
            {
                throw new InvalidOperationException("ConstellationStyleBootstrap requires a UIDocument reference.");
            }

            var root = _uiDocument.rootVisualElement;
            _navigation = new UINavigationService(root);

            var configSet = _screenConfig != null ? _screenConfig.Build() : ConstellationStyle.GetConfigSet();
            _navigation.Configure(configSet);
            _navigation.Push(ConstellationScreenIds.MainMenu);
        }

        private void OnDestroy()
        {
            _navigation?.Clear();
        }
    }
}

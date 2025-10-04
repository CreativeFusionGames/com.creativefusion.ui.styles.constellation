using System;
using CreativeFusion.Ui.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace CreativeFusion.Ui.Styles.CosmicElements
{
    /// <summary>
    /// Example MonoBehaviour that wires the CosmicElements style pack into the navigation service.
    /// </summary>
    public sealed class CosmicElementsStyleBootstrap : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("UIDocument that hosts the navigation root.")]
        private UIDocument? _uiDocument;

        [SerializeField]
        [Tooltip("Optional override of the packaged screen configuration.")]
        private CosmicElementsUIScreenConfigSetAsset? _screenConfig;

        private IUINavigationService? _navigation;

        private void Awake()
        {
            if (_uiDocument == null)
            {
                throw new InvalidOperationException("CosmicElementsStyleBootstrap requires a UIDocument reference.");
            }

            var root = _uiDocument.rootVisualElement;
            _navigation = new UINavigationService(root);

            var configSet = _screenConfig != null ? _screenConfig.Build() : CosmicElementsStyle.GetConfigSet();
            _navigation.Configure(configSet);
            _navigation.Push(CosmicElementsScreenIds.MainMenu);
        }

        private void OnDestroy()
        {
            _navigation?.Clear();
        }
    }
}

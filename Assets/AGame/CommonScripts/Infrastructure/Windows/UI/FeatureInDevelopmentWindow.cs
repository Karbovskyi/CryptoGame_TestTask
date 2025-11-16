using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows
{
    public class FeatureInDevelopmentWindow : BaseWindow
    {
        [SerializeField] private Button _closeButton;
        
        private IWindowService _windowService;

        [Inject]
        private void Construct(IWindowService windowService)
        {
            Id = WindowId.MiningSuccess;
            _windowService = windowService;
        }
        
        protected override void Subscribe()
        {
            _closeButton.onClick.AddListener(Close);
        }

        protected override void Unsubscribe()
        {
            _closeButton.onClick.RemoveListener(Close);
        }

        private void Close()
        {
            _windowService.Close(Id);
        }
    }
}
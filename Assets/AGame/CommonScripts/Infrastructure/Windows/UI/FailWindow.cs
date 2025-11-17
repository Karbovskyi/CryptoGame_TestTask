using AGame.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows
{
    public class FailWindow : BaseWindow
    {
        [SerializeField] private Button _closeButton;

        private IGameStateMachine _stateMachine;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, IWindowService windowService)
        {
            Id = WindowId.Failed;
            _windowService = windowService;
            _stateMachine = stateMachine;
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
            _stateMachine.Enter<LoadingIslandsScreenState>();
        }
    }
}
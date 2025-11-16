using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.Windows
{
    public class MiningSuccessWindow : BaseWindow
    {
        [SerializeField] private Button _returnHomeButton;

        private IGameStateMachine _gameStateMachine;
        private IWindowService _windowService;

        [Inject]
        private void Construct(IGameStateMachine stateMachine, IWindowService windowService)
        {
            Id = WindowId.MiningSuccess;

            _gameStateMachine = stateMachine;
            _windowService = windowService;
        }

        protected override void Initialize()
        {
            _returnHomeButton.onClick.AddListener(ReturnHome);
        }

        private void ReturnHome()
        {
            _windowService.Close(Id);
      
            _gameStateMachine.Enter<LoadingHomeScreenState>();
        }
    }
}
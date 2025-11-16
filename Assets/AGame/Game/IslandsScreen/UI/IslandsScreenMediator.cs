using System;
using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.GameStates.Level;
using AGame.Infrastructure.States.StateMachine;
using Code.Gameplay.Windows;
using UnityEngine.UI;

public class IslandsScreenMediator : IDisposable
{
    private readonly IGameStateMachine _stateMachine;
    private readonly IWindowService _windowService;
    private readonly Button _backButton;
    private readonly ClickableObject _islandKYC;
    private readonly ClickableObject _islandMinigame;


    public IslandsScreenMediator(IGameStateMachine stateMachine, IWindowService windowService, Button backButton, ClickableObject islandKyc, ClickableObject islandMinigame)
    {
        _stateMachine = stateMachine;
        _windowService = windowService;
        _backButton = backButton;
        _islandKYC = islandKyc;
        _islandMinigame = islandMinigame;
        
        _backButton.onClick.AddListener(OnBackButtonClick);
        _islandKYC.onClick.AddListener(OnIslandKYCClick);
        _islandMinigame.onClick.AddListener(OnIslandMinigameClick);
    }

    public void Dispose()
    {
        _backButton.onClick.RemoveAllListeners();
        _islandKYC.onClick.RemoveAllListeners();
        _islandMinigame.onClick.RemoveAllListeners();
    }

    private void OnBackButtonClick() => _stateMachine.Enter<LoadingHomeScreenState>();
    private void OnIslandKYCClick() => _windowService.Open(WindowId.FeatureInDevelopment);
    private void OnIslandMinigameClick() => _stateMachine.Enter<LoadingMinigameState, string>("Minigame1");
}
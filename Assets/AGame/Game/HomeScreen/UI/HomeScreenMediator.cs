using System;
using AGame.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class HomeScreenMediator : IDisposable
{
    private readonly IGameStateMachine _stateMachine;
    private readonly Button _infoButton;
    private readonly Button _islandsButton;
    private readonly Button _settingsButton;

    public HomeScreenMediator(IGameStateMachine stateMachine, Button infoButton, Button islandsButton, Button settingsButton)
    {
        _stateMachine = stateMachine;
        _infoButton = infoButton;
        _islandsButton = islandsButton;
        _settingsButton = settingsButton;
        
        _infoButton.onClick.AddListener(OnInfoButtonClick);
        _islandsButton.onClick.AddListener(OnIslandsButtonClick);
        _settingsButton.onClick.AddListener(OnSettingsButtonClick);
    }

    public void Dispose()
    {
        _infoButton.onClick.RemoveAllListeners();
        _islandsButton.onClick.RemoveAllListeners();
        _settingsButton.onClick.RemoveAllListeners();
    }

    private void OnInfoButtonClick() => Debug.Log("InfoButtonClick");

    private void OnIslandsButtonClick() => _stateMachine.Enter<LoadingIslandsScreenState>();

    private void OnSettingsButtonClick() => Debug.Log("SettingsButtonClick");
}
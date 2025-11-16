using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class IslandsScreenMediatorInstaller : MonoInstaller
{
    [SerializeField] private Button _backButton;
    [SerializeField] private ClickableObject _islandKYC;
    [SerializeField] private ClickableObject _islandMinigame;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<IslandsScreenMediator>().AsSingle()
            .WithArguments(_backButton, _islandKYC, _islandMinigame);
    }
}
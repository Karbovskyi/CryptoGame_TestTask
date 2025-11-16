using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

public class HomeScreenMediatorInstaller : MonoInstaller
{
    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _islandsButton;
    [SerializeField] private Button _settingsButton;

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<HomeScreenMediator>().AsSingle()
            .WithArguments(_infoButton, _islandsButton, _settingsButton);
    }
}
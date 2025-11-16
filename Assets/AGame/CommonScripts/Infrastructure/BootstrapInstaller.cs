using AGame.CommonServices.AssetManagement;
using AGame.CommonServices.RandomService;
using AGame.CommonServices.SceneLoader;
using AGame.CommonServices.TimeService;
using AGame.Infrastructure.States.Factory;
using AGame.Infrastructure.States.GameStates;
using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.GameStates.Level;
using AGame.Infrastructure.States.StateMachine;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using Zenject;

namespace AGame.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<BootstrapInstaller>().FromInstance(this).AsSingle();
        
            BindStateMachine();
            BindStateFactory();
            BindGameStates();

            BindCommonServices();
        }
        
        public void Initialize()
        {
            Container.Resolve<IGameStateMachine>().Enter<BootstrapState>();
        }
    
        private void BindStateMachine()
        {
            Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
        }

        private void BindStateFactory()
        {
            Container.BindInterfacesAndSelfTo<StateFactory>().AsSingle();
        }
        
        private void BindGameStates()
        {
            Container.BindInterfacesAndSelfTo<BootstrapState>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LoadingHomeScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<HomeScreenState>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LoadingIslandsScreenState>().AsSingle();
            Container.BindInterfacesAndSelfTo<IslandsScreenState>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<LoadingMinigameState>().AsSingle();
            Container.BindInterfacesAndSelfTo<EnterMinigameState>().AsSingle();
            Container.BindInterfacesAndSelfTo<MinigameLoopState>().AsSingle();
        }
    
        private void BindCommonServices()
        {
            Container.BindInterfacesTo<StaticDataService>().AsSingle();
            Container.BindInterfacesTo<WindowFactory>().AsSingle();
            Container.BindInterfacesTo<WindowService>().AsSingle();
            Container.BindInterfacesTo<UnityRandomService>().AsSingle();
            Container.BindInterfacesTo<UnityTimeService>().AsSingle();
            Container.BindInterfacesTo<SceneLoader>().AsSingle();
            Container.BindInterfacesTo<AssetProvider>().AsSingle();
        }
    }
}

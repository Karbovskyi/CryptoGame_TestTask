using AGame.CommonServices.AssetManagement;
using AGame.CommonServices.RandomService;
using AGame.CommonServices.SceneLoader;
using AGame.CommonServices.TimeService;
using AGame.Infrastructure.States.Factory;
using AGame.Infrastructure.States.GameStates;
using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.GameStates.Level;
using AGame.Infrastructure.States.StateMachine;
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
            Container.BindInterfacesAndSelfTo<LevelLoadingState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelEnterState>().AsSingle();
            Container.BindInterfacesAndSelfTo<LevelLoopState>().AsSingle();
        }
    
        private void BindCommonServices()
        {
            Container.Bind<IRandomService>().To<UnityRandomService>().AsSingle();
            Container.Bind<ITimeService>().To<UnityTimeService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
        }
    }
}

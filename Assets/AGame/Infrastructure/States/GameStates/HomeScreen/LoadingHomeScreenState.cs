using AGame.CommonServices.SceneLoader;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

namespace AGame.Infrastructure.States.GameStates.HomeScreen
{
  public class LoadingHomeScreenState : SimpleState
  {
    private const string HomeScreenSceneName = "HomeScreenScene";
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public override void Enter()
    {
      _sceneLoader.LoadScene(HomeScreenSceneName, EnterHomeScreenState);
    }

    private void EnterHomeScreenState()
    {
      _stateMachine.Enter<HomeScreenState>();
    }
  }
}
using AGame.CommonServices.SceneLoader;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

namespace AGame.Infrastructure.States.GameStates.Level
{
  public class LevelLoadingState : SimplePayloadState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LevelLoadingState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public override void Enter(string sceneName)
    {
      _sceneLoader.LoadScene(sceneName, EnterLevelLoopState);
    }

    private void EnterLevelLoopState()
    {
      _stateMachine.Enter<LevelEnterState>();
    }
  }
}
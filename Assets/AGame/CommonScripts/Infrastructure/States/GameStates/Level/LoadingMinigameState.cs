using AGame.CommonServices.SceneLoader;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

namespace AGame.Infrastructure.States.GameStates.Level
{
  public class LoadingMinigameState : SimplePayloadState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingMinigameState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public override void Enter(string sceneName)
    {
      _sceneLoader.LoadScene(sceneName, EnterMinigameLoopState);
    }

    private void EnterMinigameLoopState()
    {
      _stateMachine.Enter<EnterMinigameState>();
    }
  }
}
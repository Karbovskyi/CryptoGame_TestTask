using AGame.CommonServices.SceneLoader;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

public class LoadingIslandsScreenState : SimpleState
{
    private const string IslandsScreenSceneName = "IslandsScreenScene";
  
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingIslandsScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
        _stateMachine = stateMachine;
        _sceneLoader = sceneLoader;
    }
    public override void Enter()
    {
        _sceneLoader.LoadScene(IslandsScreenSceneName, EnterIslandsScreenState);
    }

    private void EnterIslandsScreenState()
    {
        _stateMachine.Enter<IslandsScreenState>();
    }
}
using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

namespace AGame.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;

    public BootstrapState(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }
    
    public override void Enter()
    {
      _stateMachine.Enter<LoadingHomeScreenState>();
    }
  }
}
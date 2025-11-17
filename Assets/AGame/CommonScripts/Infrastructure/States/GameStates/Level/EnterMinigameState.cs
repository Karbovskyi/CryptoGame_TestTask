using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

namespace AGame.Infrastructure.States.GameStates.Level
{
  public class EnterMinigameState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;

    
    public EnterMinigameState(IGameStateMachine stateMachine)
    {
      _stateMachine = stateMachine;
    }

    public override void Enter()
    {
      
      
      
      _stateMachine.Enter<MinigameLoopState>();
    }
  }
}
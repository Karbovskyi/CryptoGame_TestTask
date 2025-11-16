using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;

public class IslandsScreenState : SimpleState
{
    private readonly IGameStateMachine _stateMachine;

  
    public IslandsScreenState(IGameStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public override void Enter()
    {
    
    }
}
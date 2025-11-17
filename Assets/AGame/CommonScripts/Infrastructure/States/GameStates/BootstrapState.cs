using AGame.Infrastructure.States.GameStates.HomeScreen;
using AGame.Infrastructure.States.StateInfrastructure;
using AGame.Infrastructure.States.StateMachine;
using Code.Gameplay.StaticData;
using UnityEngine;

namespace AGame.Infrastructure.States.GameStates
{
  public class BootstrapState : SimpleState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public override void Enter()
    {
      Application.targetFrameRate = 90;
      _staticDataService.LoadAll();
      _stateMachine.Enter<LoadingHomeScreenState>();
    }
  }
}
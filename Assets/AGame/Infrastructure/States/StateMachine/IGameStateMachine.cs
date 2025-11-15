using AGame.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;

namespace AGame.Infrastructure.States.StateMachine
{
  public interface IGameStateMachine 
  {
    UniTaskVoid Enter<TState>() where TState : class, IState;
    UniTaskVoid Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>;
  }
}
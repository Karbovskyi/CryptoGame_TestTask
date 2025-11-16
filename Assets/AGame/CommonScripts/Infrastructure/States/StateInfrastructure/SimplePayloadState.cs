using Cysharp.Threading.Tasks;

namespace AGame.Infrastructure.States.StateInfrastructure
{
  public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
  {
    public virtual void Enter(TPayload payload)
    {
    }

    protected virtual void Exit()
    {
    }

     UniTask IExitableState.BeginExit()
    {
      Exit();
      return UniTask.CompletedTask;
    }

    void IExitableState.EndExit(){}
  }
}
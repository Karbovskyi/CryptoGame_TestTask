using Cysharp.Threading.Tasks;

namespace AGame.Infrastructure.States.StateInfrastructure
{
  public class EndOfFrameExitState : IState, IUpdateable, IExitableState
  {
    private UniTaskCompletionSource _exitTcs;

    protected bool ExitWasRequested => _exitTcs != null;

    public virtual void Enter()
    {
    }

    public UniTask BeginExit()
    {
      _exitTcs = new UniTaskCompletionSource();
      return _exitTcs.Task;
    }

    public void EndExit()
    {
      ExitOnEndOfFrame();
      ClearExitTask();
    }

    public void Update()
    {
      if (!ExitWasRequested)
      {
        OnUpdate();
        return;
      }
      
      ResolveExitTask();
    }

    protected virtual void ExitOnEndOfFrame()
    {
      
    }

    protected virtual void OnUpdate() { }

    private void ClearExitTask() => _exitTcs = null;

    private void ResolveExitTask()
    {
      _exitTcs?.TrySetResult();
    }
  }
}
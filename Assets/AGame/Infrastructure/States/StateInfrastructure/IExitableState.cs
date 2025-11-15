using Cysharp.Threading.Tasks;

namespace AGame.Infrastructure.States.StateInfrastructure
{
  public interface IExitableState
  {
    UniTask BeginExit();
    void EndExit();
  }
}
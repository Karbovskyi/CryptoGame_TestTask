using AGame.Infrastructure.States.StateInfrastructure;

namespace AGame.Infrastructure.States.Factory
{
  public interface IStateFactory
  {
    T GetState<T>() where T : class, IExitableState;
  }
}
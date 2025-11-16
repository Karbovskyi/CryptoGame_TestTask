using UnityEngine;

namespace Code.Gameplay.Windows
{
  public class BaseWindow : MonoBehaviour
  {
    public WindowId Id { get; protected set; }

    private void Awake() =>
      OnAwake();

    private void Start()
    {
      Initialize();
      Subscribe();
    }

    private void OnDestroy() =>
      Cleanup();


    protected virtual void OnAwake()
    {
    }

    protected virtual void Initialize()
    {
    }

    protected virtual void Subscribe()
    {
    }

    protected virtual void Unsubscribe()
    {
    }

    protected virtual void Cleanup() => 
      Unsubscribe();
  }
}
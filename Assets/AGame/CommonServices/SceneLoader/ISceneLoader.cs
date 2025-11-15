using System;

namespace AGame.CommonServices.SceneLoader
{
  public interface ISceneLoader
  {
    void LoadScene(string name, Action onLoaded = null);
  }
}
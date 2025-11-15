using UnityEngine;

namespace AGame.CommonServices.AssetManagement
{
  public interface IAssetProvider
  {
    GameObject LoadAsset(string path);
    T LoadAsset<T>(string path) where T : Component;
  }
}
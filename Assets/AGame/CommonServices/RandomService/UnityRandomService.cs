using System.Collections.Generic;

namespace AGame.CommonServices.RandomService
{
  public class UnityRandomService : IRandomService
  {
    public float Range(float inclusiveMin, float inclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, inclusiveMax);

    public int Range(int inclusiveMin, int exclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, exclusiveMax);

    public void Shuffle<T>(IList<T> list)
    {
      if (list == null || list.Count <= 1)
        return;

      for (int i = list.Count - 1; i > 0; i--)
      {
        int j = Range(0, i + 1);
        T temp = list[i];
        list[i] = list[j];
        list[j] = temp;
      }
    }
  }
}
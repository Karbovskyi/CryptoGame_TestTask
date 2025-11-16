using System.Collections.Generic;

namespace AGame.CommonServices.RandomService
{
  public interface IRandomService
  {
    float Range(float inclusiveMin, float inclusiveMax);
    int Range(int inclusiveMin, int exclusiveMax);
    
    void Shuffle<T>(IList<T> list);
  }
}
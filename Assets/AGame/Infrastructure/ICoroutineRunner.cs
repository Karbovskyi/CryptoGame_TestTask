using System.Collections;
using UnityEngine;

namespace AGame.Infrastructure
{
  public interface ICoroutineRunner
  {
    Coroutine StartCoroutine(IEnumerator load);
  }
}
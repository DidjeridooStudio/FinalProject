using System.Collections;
using UnityEngine;

public interface ICoroutinesPerformer
{
    Coroutine StartPerform(IEnumerator coroutine);
    void StopPerform(IEnumerator coroutine);
}

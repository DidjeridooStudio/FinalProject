using System.Collections;
using UnityEngine;

public class CoroutinesPerformer : MonoBehaviour, ICoroutinesPerformer
{
    private void Awake() => DontDestroyOnLoad(this);

    #region Interface

    public Coroutine StartPerform(IEnumerator coroutine) => StartCoroutine(coroutine);

    public void StopPerform(IEnumerator coroutine) => StopCoroutine(coroutine);

    #endregion
}

using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment
{
    public interface ICoroutinesPerformer
    {
        Coroutine StartPerform(IEnumerator coroutine);
        void StopPerform(Coroutine coroutine);
    }
}
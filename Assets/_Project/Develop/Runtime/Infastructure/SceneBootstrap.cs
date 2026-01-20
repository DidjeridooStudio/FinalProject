using System.Collections;
using UnityEngine;

public abstract class SceneBootstrap : MonoBehaviour
{
    public abstract void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null);

    public abstract IEnumerator Initialize();

    public abstract void Run();
}

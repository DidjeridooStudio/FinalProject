using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

public class ScenesSwitcherService
{
    private readonly ScenesLoaderService _scenesLoaderService;
    private readonly ILoadingScreen _loadingScreen;
    private readonly DIContainer _projectContainer;

    public ScenesSwitcherService(ScenesLoaderService scenesLoaderService, ILoadingScreen loadingScreen, DIContainer projectContainer)
    {
        _scenesLoaderService = scenesLoaderService;
        _loadingScreen = loadingScreen;
        _projectContainer = projectContainer;
    }

    public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
    {
        _loadingScreen.Show();

        yield return _scenesLoaderService.LoadAsync(Scenes.Empty);
        yield return _scenesLoaderService.LoadAsync(sceneName);

        SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

        if (sceneBootstrap == null)
            throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

        DIContainer sceneContainer = new DIContainer(_projectContainer);

        sceneBootstrap.ProcessRegistrations(sceneContainer, sceneArgs);

        yield return sceneBootstrap.Initialize();

        _loadingScreen.Hide();

        sceneBootstrap.Run();
    }
}

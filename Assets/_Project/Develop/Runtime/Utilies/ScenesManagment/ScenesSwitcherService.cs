using Assets._Project.Develop.Runtime.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.LoadingScreen;
using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.Utilies.ScenesManagment
{
    public class ScenesSwitcherService
    {
        private readonly ScenesLoaderService _scenesLoaderService;
        private readonly ILoadingScreen _loadingScreen;
        private readonly DIContainer _projectContainer;

        private DIContainer _currentSceneContainer;

        public ScenesSwitcherService(ScenesLoaderService scenesLoaderService, ILoadingScreen loadingScreen, DIContainer projectContainer)
        {
            _scenesLoaderService = scenesLoaderService;
            _loadingScreen = loadingScreen;
            _projectContainer = projectContainer;
        }

        public IEnumerator ProcessSwitchTo(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _loadingScreen.Show();

            _currentSceneContainer?.Dispose();

            yield return _scenesLoaderService.LoadAsync(Scenes.Empty);
            yield return _scenesLoaderService.LoadAsync(sceneName);

            SceneBootstrap sceneBootstrap = Object.FindObjectOfType<SceneBootstrap>();

            if (sceneBootstrap == null)
                throw new NullReferenceException(nameof(sceneBootstrap) + " not found");

            _currentSceneContainer = new DIContainer(_projectContainer);

            sceneBootstrap.ProcessRegistrations(_currentSceneContainer, sceneArgs);

            _currentSceneContainer.Initialize();

            yield return sceneBootstrap.Initialize();

            _loadingScreen.Hide();

            sceneBootstrap.Run();
        }
    }
}
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using UnityEngine.SceneManagement;

namespace Assets._Project.Develop.Runtime.UI.StatsUpgradePopup
{
    public class CharacterPreviewPresenter : IPresenter
    {
        private ScenesLoaderService _sceneLoader;
        private ICoroutinesPerformer _coroutinesPerformer;

        public CharacterPreviewPresenter(ScenesLoaderService sceneLoader, ICoroutinesPerformer coroutinePerformer)
        {
            _sceneLoader = sceneLoader;
            _coroutinesPerformer = coroutinePerformer;
        }

        public void Initialize()
        {
            _coroutinesPerformer.StartPerform(_sceneLoader.LoadAsync(Scenes.CharacterPreviewScene, LoadSceneMode.Additive));
        }

        public void Dispose()
        {
            _coroutinesPerformer.StartPerform(_sceneLoader.UnloadAsync(Scenes.CharacterPreviewScene));
        }
    }
}

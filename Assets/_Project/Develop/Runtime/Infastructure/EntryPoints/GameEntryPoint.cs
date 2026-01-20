using System.Collections;
using UnityEngine;

public class GameEntryPoint : MonoBehaviour
{
    private void Awake()
    {
        SetupAppSettings();

        DIContainer projectContainer = new DIContainer();

        ProjectContextRegistrations.Process(projectContainer);

        projectContainer.Resolve<ICoroutinesPerformer>().StartPerform(Initialize(projectContainer));
    }

    private void SetupAppSettings()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    private IEnumerator Initialize(DIContainer container)
    {
        ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();
        ScenesSwitcherService scenesSwitcherService = container.Resolve<ScenesSwitcherService>();

        loadingScreen.Show();

        yield return container.Resolve<ConfigsProviderService>().LoadAsync();

        yield return new WaitForSeconds(1);

        loadingScreen.Hide();

        yield return scenesSwitcherService.ProcessSwitchTo(Scenes.MainMenu);
    }
}

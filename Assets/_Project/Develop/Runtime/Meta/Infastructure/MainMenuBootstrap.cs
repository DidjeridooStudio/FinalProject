using System.Collections;

public class MainMenuBootstrap : SceneBootstrap
{
    private DIContainer _container;
    private ModeSelectionService _modeSelectionService;
    private ProgressManagementService _progressManagementService;

    public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
    {
        _container = container;

        MainMenuContextRegistrations.Process(_container);
    }

    public override IEnumerator Initialize()
    {
        yield break;
    }

    public override void Run()
    {
        _modeSelectionService = _container.Resolve<ModeSelectionService>();
        _progressManagementService = _container.Resolve<ProgressManagementService>();
    }

    private void Update()
    {
        if (_modeSelectionService != null)
            _modeSelectionService.Update();

        if (_progressManagementService != null)
            _progressManagementService.Update();
    }
}

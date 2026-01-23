using System.Collections;
using UnityEngine;

public class MainMenuBootstrap : SceneBootstrap
{
    private DIContainer _container;
    private ModeSelectionService _modeSelectionService;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _modeSelectionService.Select(ModeTypes.Numbers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _modeSelectionService.Select(ModeTypes.Letters);
        }
    }
}

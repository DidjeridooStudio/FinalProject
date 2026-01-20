using System.Collections;
using UnityEngine;

public class MainMenuBootstrap : SceneBootstrap
{
    private DIContainer _container;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartGame(ModeTypes.Numbers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartGame(ModeTypes.Letters);
        }
    }

    private void StartGame(ModeTypes mode)
    {
        ConfigsProviderService configService = _container.Resolve<ConfigsProviderService>();

        string symbolSet = string.Empty;

        switch (mode)
        {
            case ModeTypes.Letters:
                LettersConfig lettersConfig = configService.GetConfig<LettersConfig>();
                symbolSet = lettersConfig.SymbolSet;
                break;
            case ModeTypes.Numbers:
                NumbersConfig numbersConfig = configService.GetConfig<NumbersConfig>();
                symbolSet = numbersConfig.SymbolSet;
                break;
            default:
                break;
        }

        if (symbolSet == string.Empty)
            return;

        ScenesSwitcherService scenesSwitcherService = _container.Resolve<ScenesSwitcherService>();

        _container.Resolve<ICoroutinesPerformer>().StartPerform(scenesSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(symbolSet)));
    }
}

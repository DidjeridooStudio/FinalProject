
using UnityEngine;

public class ModeSelectionService
{
    private readonly ConfigsProviderService _configsProviderService;
    private readonly ScenesSwitcherService _scenesSwitcherService;
    private readonly ICoroutinesPerformer _coroutinesPerformer;

    public ModeSelectionService(ConfigsProviderService configsProviderService, ScenesSwitcherService scenesSwitcherService, ICoroutinesPerformer coroutinesPerformer)
    {
        _configsProviderService = configsProviderService;
        _scenesSwitcherService = scenesSwitcherService;
        _coroutinesPerformer = coroutinesPerformer;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Select(ModeTypes.Numbers);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Select(ModeTypes.Letters);
        }
    }

    public void Select(ModeTypes mode)
    {
        LevelConfig levelConfig = _configsProviderService.GetConfig<LevelConfig>();

        string symbolSet = string.Empty;

        switch (mode)
        {
            case ModeTypes.Letters:
                symbolSet = levelConfig.GetValueFor(ModeTypes.Letters);
                break;
            case ModeTypes.Numbers:
                symbolSet = levelConfig.GetValueFor(ModeTypes.Numbers);
                break;
            default:
                break;
        }

        _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.Gameplay, new GameplayInputArgs(symbolSet, levelConfig.SymbolsQuanity, levelConfig.MoneyBet)));
    }
}

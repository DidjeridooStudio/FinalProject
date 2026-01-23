using System;
using UnityEngine;

public class GameplayCircle : IDisposable
{
    private ScenesSwitcherService _scenesSwitcherService;
    private ICoroutinesPerformer _coroutinesPerformer;
    private GenerateRandomStringService _generateRandomStringService;
    private ReadUserInputService _userInputService;

    private string _symbolSet;
    private int _symbolsQuanity;
    private GameMode _gameMode;
    private bool _hasVictory;

    public GameplayCircle(ScenesSwitcherService scenesSwitcherService, ICoroutinesPerformer coroutinesPerformer, GenerateRandomStringService generateRandomStringService, ReadUserInputService userInputService)
    {
        _scenesSwitcherService = scenesSwitcherService;
        _coroutinesPerformer = coroutinesPerformer;
        _generateRandomStringService = generateRandomStringService;
        _userInputService = userInputService;
    }

    public void Prepare(GameplayInputArgs args)
    {
        _symbolSet = args.SymbolSet;
        _symbolsQuanity = args.SymbolsQuanity;
        _generateRandomStringService.Prepare(_symbolSet, _symbolsQuanity);
    }

    public void Launch()
    {
        _gameMode = new GameMode(_generateRandomStringService, _userInputService, _symbolsQuanity);

        _gameMode.Victory += OnGameModeVictory;
        _gameMode.Defeat += OnGameModeDefeat;

        _gameMode.Start();
    }

    public void Update(float deltaTime)
    {
        _gameMode?.Update(deltaTime);

        if (Input.GetKeyUp(KeyCode.Space) && _gameMode.IsRunning == false)
        {
            if (_hasVictory)
                SwitchScene(Scenes.MainMenu);
            else
                SwitchScene(Scenes.Gameplay, new GameplayInputArgs(_symbolSet, _symbolsQuanity));
        }
    }

    private void OnGameModeEnded()
    {
        if (_gameMode != null)
        {
            _gameMode.Victory -= OnGameModeVictory;
            _gameMode.Defeat -= OnGameModeDefeat;
        }
    }

    private void OnGameModeVictory()
    {
        Debug.Log("Вы победили. Нажмите пробел для перехода в главное меню");

        _hasVictory = true;

        OnGameModeEnded();
    }

    private void OnGameModeDefeat()
    {
        Debug.Log("Вы проиграли. Нажмите пробел для перезапуска игры");

        _hasVictory = false;

        OnGameModeEnded();
    }

    private void SwitchScene(string sceneName, IInputSceneArgs sceneArgs = null)
    {
        _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(sceneName, sceneArgs));
    }

    #region Interface

    public void Dispose()
    {
        OnGameModeEnded();
    }

    #endregion
}

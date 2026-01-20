using System;
using UnityEngine;

public class GameplayCircle : IDisposable
{
    private string _symbolSet;
    private GameMode _gameMode;
    private DIContainer _container;

    private bool _hasVictory;

    public GameplayCircle(string symbolSet, DIContainer container)
    {
        _symbolSet = symbolSet;
        _container = container;
    }

    public void Prepare()
    {
        
    }

    public void Launch()
    {
        _gameMode = new GameMode(_symbolSet);

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
                SwitchScene(Scenes.Gameplay, new GameplayInputArgs(_symbolSet));
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
        ScenesSwitcherService scenesSwitcherService = _container.Resolve<ScenesSwitcherService>();

        _container.Resolve<ICoroutinesPerformer>().StartPerform(scenesSwitcherService.ProcessSwitchTo(sceneName, sceneArgs));
    }

    #region Interface

    public void Dispose()
    {
        OnGameModeEnded();
    }

    #endregion
}

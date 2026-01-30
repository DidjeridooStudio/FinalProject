using Assets._Project.Develop.Runtime.Gameplay.Utilities;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infastructure
{
    public class GameplayCircle : IDisposable
    {
        private ScenesSwitcherService _scenesSwitcherService;
        private ICoroutinesPerformer _coroutinesPerformer;
        private GenerateRandomStringService _generateRandomStringService;
        private ReadUserInputService _userInputService;
        private WalletService _walletService;
        private ProgressionService _progressionService;
        private GameplayInputArgs _inputArgs;
        private PlayerDataProvider _playerDataProvider;

        private GameMode _gameMode;
        private bool _hasVictory;

        public GameplayCircle(
            ScenesSwitcherService scenesSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            GenerateRandomStringService generateRandomStringService,
            ReadUserInputService userInputService,
            ProgressionService progressionService,
            WalletService walletService,
            GameplayInputArgs args,
            PlayerDataProvider playerDataProvider)
        {
            _scenesSwitcherService = scenesSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _generateRandomStringService = generateRandomStringService;
            _userInputService = userInputService;
            _progressionService = progressionService;
            _walletService = walletService;
            _inputArgs = args;
            _playerDataProvider = playerDataProvider;
        }

        public void Prepare()
        {

        }

        public void Launch()
        {
            _gameMode = new GameMode(_generateRandomStringService, _userInputService, _inputArgs.SymbolsQuanity);

            _gameMode.Victory += OnGameModeVictory;
            _gameMode.Defeat += OnGameModeDefeat;

            _gameMode.Start();
        }

        public void Update(float deltaTime)
        {
            _gameMode?.Update(deltaTime);

            if (_walletService.GetCurrency(CurrencyTypes.Gold).Value == 0)
                RunningOutMoneyDefeat();

            if (Input.GetKeyUp(KeyCode.Space) && _gameMode.IsRunning == false)
            {
                if (_hasVictory)
                    SwitchScene(Scenes.MainMenu);
                else
                    SwitchScene(Scenes.Gameplay, new GameplayInputArgs(_inputArgs.SymbolSet, _inputArgs.SymbolsQuanity, _inputArgs.MoneyBet));
            }
        }

        private void OnGameModeEnded()
        {
            _coroutinesPerformer?.StartPerform(_playerDataProvider.Save());

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

            _walletService.AddCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet);

            _progressionService.IncreaseWinnings();

            Debug.Log("Gold " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
            Debug.Log("Winnings " + _progressionService.WinningsQuantity.Value);

            OnGameModeEnded();
        }

        private void OnGameModeDefeat()
        {
            Debug.Log("Вы проиграли. Нажмите пробел для перезапуска игры");

            _hasVictory = false;

            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet))
                _walletService.SpendCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet);
            else
                _walletService.SpendCurrency(CurrencyTypes.Gold, _walletService.GetCurrency(CurrencyTypes.Gold).Value);

            _progressionService.IncreaseLosses();

            Debug.Log("Gold " + _walletService.GetCurrency(CurrencyTypes.Gold).Value);
            Debug.Log("Losses " + _progressionService.LossesQuantity.Value);

            OnGameModeEnded();
        }

        private void SwitchScene(string sceneName, IInputSceneArgs sceneArgs = null)
        {
            _coroutinesPerformer?.StartPerform(_scenesSwitcherService.ProcessSwitchTo(sceneName, sceneArgs));
        }

        private void RunningOutMoneyDefeat()
        {
            Debug.Log("Вы проиграли все свои деньги. Весь прогресс был сброшен");

            _progressionService.Reset();

            _walletService.ResetToStartConfig();

            OnGameModeEnded();

            SwitchScene(Scenes.MainMenu);
        }

        #region Interface

        public void Dispose()
        {
            OnGameModeEnded();
        }

        #endregion
    }
}
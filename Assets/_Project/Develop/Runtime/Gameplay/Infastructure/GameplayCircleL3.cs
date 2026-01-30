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
    public class GameplayCircleL3 : IDisposable
    {
        public event Action RandomStringSetted;

        private ICoroutinesPerformer _coroutinesPerformer;
        private GenerateRandomStringService _generateRandomStringService;
        private WalletService _walletService;
        private ProgressionService _progressionService;
        private GameplayInputArgs _inputArgs;
        private PlayerDataProvider _playerDataProvider;

        private string _randomString = string.Empty;

        public string RandomString => _randomString;

        public GameplayCircleL3(
            ICoroutinesPerformer coroutinesPerformer,
            GenerateRandomStringService generateRandomStringService,
            ProgressionService progressionService,
            WalletService walletService,
            GameplayInputArgs args,
            PlayerDataProvider playerDataProvider)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _generateRandomStringService = generateRandomStringService;
            _progressionService = progressionService;
            _walletService = walletService;
            _inputArgs = args;
            _playerDataProvider = playerDataProvider;
        }

        public string SceneSwitchTo { get; private set; }

        public GameplayInputArgs InputArgs => _inputArgs;

        public void Prepare()
        {

        }

        public void Launch()
        {
            _randomString = _generateRandomStringService.Generate();
            RandomStringSetted?.Invoke();
        }

        public string ProcessUserInput(string userString)
        {
            if (userString == _randomString)
            {
                ProcessVictory();
                SceneSwitchTo = Scenes.MainMenu;
                return "Вы победили. Нажмите OK для перехода в главное меню";
            }
            else
            {
                return ProcessDefeat();
            }
        }

        private void OnGameEnded()
        {
            _coroutinesPerformer?.StartPerform(_playerDataProvider.Save());
        }

        private void ProcessVictory()
        {
            _walletService.AddCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet);

            _progressionService.IncreaseWinnings();

            OnGameEnded();
        }

        private string ProcessDefeat()
        {
            string message = string.Empty;

            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet))
                _walletService.SpendCurrency(CurrencyTypes.Gold, _inputArgs.MoneyBet);
            else
                _walletService.SpendCurrency(CurrencyTypes.Gold, _walletService.GetCurrency(CurrencyTypes.Gold).Value);

            _progressionService.IncreaseLosses();

            if (_walletService.GetCurrency(CurrencyTypes.Gold).Value == 0)
            {
                RunningOutMoneyDefeat();
                SceneSwitchTo = Scenes.MainMenu;
                message =  "Вы проиграли все свои деньги. Весь прогресс был сброшен. Нажмите OK для перехода в главное меню";
            }
            else
            {
                SceneSwitchTo = Scenes.Gameplay;
                message = "Вы проиграли. Нажмите OK для перезапуска игры";
            }

            OnGameEnded();

            return message;
        }

        private void RunningOutMoneyDefeat()
        {
            _progressionService.Reset();

            _walletService.ResetToStartConfig();
        }

        #region Interface

        public void Dispose()
        {
            OnGameEnded();
        }

        #endregion
    }
}
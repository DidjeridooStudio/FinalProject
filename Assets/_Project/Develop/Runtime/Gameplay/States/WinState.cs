using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class WinState : EndGameState, IUpdatebableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ScenesSwitcherService _scenesSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly WalletService _walletService;
        private readonly ProgressionService _progressionService;
        private GameplayInputArgs _inputArgs;

        public WinState(
            IInputService inputService,
            PlayerDataProvider playerDataProvider,
            ScenesSwitcherService scenesSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            WalletService walletService,
            ProgressionService progressionService,
            GameplayInputArgs inputArgs) : base(inputService)
        {
            _playerDataProvider = playerDataProvider;
            _scenesSwitcherService = scenesSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _progressionService = progressionService;
            _inputArgs = inputArgs;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Win");

            _walletService.AddCurrency(CurrencyTypes.Gold, _inputArgs.LevelConfig.GoldWinReward);
            _progressionService.IncreaseWinnings();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.S))
                _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
        }
    }
}

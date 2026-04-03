using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.GamePlay;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class WinState : EndGameState, IUpdatebableState
    {
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly WalletService _walletService;
        private readonly ProgressionService _progressionService;
        private GameplayInputArgs _inputArgs;
        private readonly GameplayPopupService _popupService;

        public WinState(
            IInputService inputService,
            PlayerDataProvider playerDataProvider,
            ICoroutinesPerformer coroutinesPerformer,
            WalletService walletService,
            ProgressionService progressionService,
            GameplayInputArgs inputArgs,
            GameplayPopupService gameplayPopupService) : base(inputService)
        {
            _playerDataProvider = playerDataProvider;
            _coroutinesPerformer = coroutinesPerformer;
            _walletService = walletService;
            _progressionService = progressionService;
            _inputArgs = inputArgs;
            _popupService = gameplayPopupService;
        }

        public override void Enter()
        {
            base.Enter();

            _walletService.AddCurrency(CurrencyTypes.Gold, _inputArgs.LevelConfig.GoldWinReward);
            _walletService.AddCurrency(CurrencyTypes.Diamond, _inputArgs.LevelConfig.DiamondWinReward);
            _progressionService.IncreaseWinnings();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupService.OpenWinPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

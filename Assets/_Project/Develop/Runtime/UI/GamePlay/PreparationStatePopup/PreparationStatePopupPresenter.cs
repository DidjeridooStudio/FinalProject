using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.PreparationStatePopup
{
    public class PreparationStatePopupPresenter : PopupPresenterBase
    {
        private readonly PreparationStatePopupView _view;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly PlayerHolderService _playerHolderService;

        public PreparationStatePopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            PreparationStatePopupView view,
            ConfigsProviderService configsProviderService,
            PlayerHolderService playerHolderService) : base(coroutinesPerformer)
        {
            _view = view;
            _configsProviderService = configsProviderService;
            _playerHolderService = playerHolderService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Dispose()
        {
            base.Dispose();

            _view.MineButtonClicked -= OnMineButtonClicked;
            _view.ToxicPuddleButtonClicked -= OnToxicPuddleButtonClicked;
            _view.TurretButtonClicked -= OnTurretButtonClicked;
        }

        public override void Subscribe()
        {
            _view.MineButtonClicked += OnMineButtonClicked;
            _view.ToxicPuddleButtonClicked += OnToxicPuddleButtonClicked;
            _view.TurretButtonClicked += OnTurretButtonClicked;
        }

        public override void Unsubscribe()
        {
            _view.MineButtonClicked -= OnMineButtonClicked;
            _view.ToxicPuddleButtonClicked -= OnToxicPuddleButtonClicked;
            _view.TurretButtonClicked -= OnTurretButtonClicked;
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            Unsubscribe();
        }

        private void OnMineButtonClicked()
        {
            _playerHolderService.Player.ProtectionObjectConfig.Value = _configsProviderService.GetConfig<MineEntityConfig>();
        }

        private void OnToxicPuddleButtonClicked()
        {
            _playerHolderService.Player.ProtectionObjectConfig.Value = _configsProviderService.GetConfig<ToxicPuddleConfig>();
        }

        private void OnTurretButtonClicked()
        {
            _playerHolderService.Player.ProtectionObjectConfig.Value = _configsProviderService.GetConfig<TurretEntityConfig>();
        }
    }
}

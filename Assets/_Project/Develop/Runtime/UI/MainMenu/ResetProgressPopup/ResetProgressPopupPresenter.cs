using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.Core.MessagePopup;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;

namespace Assets._Project.Develop.Runtime.UI.Core.ResetProgressPopup
{
    public class ResetProgressPopupPresenter : PopupPresenterBase
    {
        private readonly ResetProgressPopupView _view;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly WalletService _walletService;
        private readonly ProgressionService _progressionService;
        private readonly MainMenuPopupService _popupService;
        private readonly PlayerDataProvider _playerDataProvider;

        private int _moneyToResetProgress;

        public ResetProgressPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            ResetProgressPopupView view,
            ConfigsProviderService configsProviderService,
            WalletService walletService,
            ProgressionService progressionService,
            MainMenuPopupService popupService,
            PlayerDataProvider playerDataProvider) : base(coroutinesPerformer)
        {
            _view = view;
            _configsProviderService = configsProviderService;
            _walletService = walletService;
            _progressionService = progressionService;
            _popupService = popupService;
            _playerDataProvider = playerDataProvider;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Initialize()
        {
            base.Initialize();

            _moneyToResetProgress = _configsProviderService.GetConfig<StandardSettingsConfig>().MoneyToResetProgress;

            _view.SetTitle($"Для сброса прогресса требуется {_moneyToResetProgress} золотых");
        }

        public override void Dispose()
        {
            base.Dispose();

            _view.ConfirmButtonClicked -= OnConfirmButtonClicked;
            _view.CancelButtonClicked -= OnCancelButtonClicked;
        }

        public override void Subscribe()
        {
            _view.ConfirmButtonClicked += OnConfirmButtonClicked;
            _view.CancelButtonClicked += OnCancelButtonClicked;
        }

        public override void Unsubscribe()
        {
            _view.ConfirmButtonClicked -= OnConfirmButtonClicked;
            _view.CancelButtonClicked -= OnCancelButtonClicked;
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

        private void OnConfirmButtonClicked()
        {
            if (_walletService.EnoughCurrency(CurrencyTypes.Gold, _moneyToResetProgress))
            {
                _progressionService.Reset();
                _walletService.SpendCurrency(CurrencyTypes.Gold, _moneyToResetProgress);

                if (_walletService.GetCurrency(CurrencyTypes.Gold).Value == 0)
                {
                    OpenMessagePopup("Нельзя тратить все свои деньги, вам не на что будет играть");

                    _walletService.AddCurrency(CurrencyTypes.Gold, _moneyToResetProgress);
                    return;
                }

                _coroutinesPerformer?.StartPerform(_playerDataProvider.SaveAsync());

                OpenMessagePopup("Прогресс успешно сброшен");
            }
            else
            {
                OpenMessagePopup("У вас недостаточно золота");
            }
        }

        private void OnCancelButtonClicked() => _view.OnCloseButtonClicked();

        private void OpenMessagePopup(string message)
        {
            MessagePopupPresenter messagePopup = _popupService.OpenMessagePopup();
            messagePopup.View.SetText(message);
        }
    }
}

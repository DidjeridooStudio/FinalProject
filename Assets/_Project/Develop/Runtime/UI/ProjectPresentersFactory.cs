using Assets._Project.Develop.Runtime.Configs.Meta.Stats;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.MessagePopup;
using Assets._Project.Develop.Runtime.UI.StatsUpgradePopup;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using Assets.CourseGame.Develop.MainMenu.StatsUpgradeFeature;

namespace Assets._Project.Develop.Runtime.UI
{
    public class ProjectPresentersFactory
    {
        private readonly DIContainer _container;

        public ProjectPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public UpgradableStatPresenter CreateUpgradableStatPresenter(UpgradableStatView view, StatTypes statType)
        {
            return new UpgradableStatPresenter(
                view,
                statType,
                _container.Resolve<ConfigsProviderService>().GetConfig<StatsViewConfig>(),
                _container.Resolve<StatsUpgradeService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>());
        }

        public StatsUpgradePopupPresenter CreateStatsUpgradePopupPresenter(StatsUpgradePopupView view)
        {
            return new StatsUpgradePopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<StatsUpgradeService>(),
                _container.Resolve<ViewsFactory>());
        }

        public CurrencyPresenter CreateCurrencyPresenter(CurrencyTypes currencyType, IReadOnlyVariable<int> currency, IconTextView iconTextView)
        {
            return new CurrencyPresenter(currencyType, currency, _container.Resolve<ConfigsProviderService>().GetConfig<CurrencyIconsConfig>(), iconTextView);
        }

        public WalletPresenter CreateWalletPresenter(IconTextListView view)
        {
            return new WalletPresenter(
                _container.Resolve<WalletService>(),
                this,
                _container.Resolve<ViewsFactory>(),
                view);
        }

        public ProgressionPresenter CreateProgressionPresenter(ProgressionView view)
        {
            return new ProgressionPresenter(_container.Resolve<ProgressionService>(), view);
        }

        public MessagePopupPresenter CreateMessagePopupPresenter(MessagePopupView view) => new MessagePopupPresenter(_container.Resolve<ICoroutinesPerformer>(), view);
    }
}

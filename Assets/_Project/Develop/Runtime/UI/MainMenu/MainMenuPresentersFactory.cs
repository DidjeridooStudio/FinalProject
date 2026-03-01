using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Meta.Utilities;
using Assets._Project.Develop.Runtime.UI.Core.ResetProgressPopup;
using Assets._Project.Develop.Runtime.UI.Core.StartGamePopup;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPresentersFactory
    {
        private readonly DIContainer _container;

        public MainMenuPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public MainMenuScreenPresenter CreateMainMenuScreenPresenter(MainMenuScreenView view) => 
            new MainMenuScreenPresenter(
                view,
                _container.Resolve<ProjectPresentersFactory>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<ScenesSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());

        public StartGamePopupPresenter CreateStartGamePopupPresenter(StartGamePopupView view)
        {
            return new StartGamePopupPresenter(_container.Resolve<ICoroutinesPerformer>(), view, _container.Resolve<ModeSelectionService>());
        }

        public ResetProgressPopupPresenter CreateResetProgressPopupPresenter(ResetProgressPopupView view)
        {
            return new ResetProgressPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ConfigsProviderService>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ProgressionService>(),
                _container.Resolve<MainMenuPopupService>(),
                _container.Resolve<PlayerDataProvider>());
        }
    }
}

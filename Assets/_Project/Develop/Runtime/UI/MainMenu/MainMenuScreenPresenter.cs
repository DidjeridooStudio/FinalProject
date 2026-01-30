using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screenView;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPopupService _menuPopupService;

        private readonly List<IPresenter> _childPresenters = new List<IPresenter>();

        public MainMenuScreenPresenter(MainMenuScreenView screeView, ProjectPresentersFactory projectPresentersFactory, MainMenuPopupService menuPopupService)
        {
            _screenView = screeView;
            _projectPresentersFactory = projectPresentersFactory;
            _menuPopupService = menuPopupService;
        }

        #region Interface

        public void Initialize()
        {
            _screenView.OpenPopupStartGameButtonClicked += OnOpenPopupStartGameButtonClicked;
            _screenView.OpenPopupResetProgressClicked += OnOpenPopupResetProgressClicked;

            CreateWalletPresenter();
            CreateProgressionPresenter();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void Dispose()
        {
            _screenView.OpenPopupStartGameButtonClicked -= OnOpenPopupStartGameButtonClicked;
            _screenView.OpenPopupResetProgressClicked += OnOpenPopupResetProgressClicked;

            foreach (IPresenter presenter in _childPresenters)
                presenter.Dispose();

            _childPresenters.Clear();
        }

        #endregion

        private void CreateWalletPresenter()
        {
            WalletPresenter walletPresenter = _projectPresentersFactory.CreateWalletPresenter(_screenView.WalletView);

            _childPresenters.Add(walletPresenter);
        }

        private void CreateProgressionPresenter()
        {
            ProgressionPresenter progressionPresenter = _projectPresentersFactory.CreateProgressionPresenter(_screenView.ProgressionView);

            _childPresenters.Add(progressionPresenter);
        }

        private void OnOpenPopupStartGameButtonClicked() => _menuPopupService.OpenStartGamePopup();
        private void OnOpenPopupResetProgressClicked() => _menuPopupService.OpenResetProgress();
    }
}

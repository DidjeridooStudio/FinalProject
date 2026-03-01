using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenPresenter : IPresenter
    {
        private readonly MainMenuScreenView _screenView;
        private readonly ProjectPresentersFactory _projectPresentersFactory;
        private readonly MainMenuPopupService _menuPopupService;
        private readonly ScenesSwitcherService _scenesSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        private readonly List<IPresenter> _childPresenters = new List<IPresenter>();

        public MainMenuScreenPresenter(MainMenuScreenView screeView, ProjectPresentersFactory projectPresentersFactory, MainMenuPopupService menuPopupService, ScenesSwitcherService scenesSwitcherService, ICoroutinesPerformer coroutinesPerformer)
        {
            _screenView = screeView;
            _projectPresentersFactory = projectPresentersFactory;
            _menuPopupService = menuPopupService;
            _scenesSwitcherService = scenesSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
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

        //private void OnOpenPopupStartGameButtonClicked() => _menuPopupService.OpenStartGamePopup();
        private void OnOpenPopupStartGameButtonClicked() => _coroutinesPerformer?.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.Gameplay));
        private void OnOpenPopupResetProgressClicked() => _menuPopupService.OpenResetProgress();
    }
}

using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.GamePlay.HealthPresenter;
using Assets._Project.Develop.Runtime.UI.GamePlay.Stages;
using Assets._Project.Develop.Runtime.UI.Wallet;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screenView;
        private readonly GameplayPresentersFactory _gameplayPresentersFactory;
        private readonly ProjectPresentersFactory _projectPresentersFactory;

        private readonly List<IPresenter> _childPresenters = new List<IPresenter>();

        private EntitiesHealthDisplayPresenter _entitiesHealthDisplayPresenter;

        public GameplayScreenPresenter(GameplayScreenView screeView, GameplayPresentersFactory gameplayPresentersFactory, ProjectPresentersFactory projectPresentersFactory)
        {
            _screenView = screeView;
            _gameplayPresentersFactory = gameplayPresentersFactory;
            _projectPresentersFactory = projectPresentersFactory;
        }

        #region Interface

        public void Initialize()
        {
            CreateWalletPresenter();
            CreateStagePresenter();
            CreateEntitiesHealthDisplayPresenter();

            foreach (IPresenter presenter in _childPresenters)
                presenter.Initialize();
        }

        public void LateUpdate()
        {
            _entitiesHealthDisplayPresenter.LateUpdate();
        }

        public void Dispose()
        {
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

        private void CreateStagePresenter()
        {
            StagePresenter stagePresenter = _gameplayPresentersFactory.CreateStagePresenter(_screenView.StageView);

            _childPresenters.Add(stagePresenter);
        }

        private void CreateEntitiesHealthDisplayPresenter()
        {
            _entitiesHealthDisplayPresenter = _gameplayPresentersFactory.CreateEntitiesHealthDisplayPresenter(_screenView.EntitiesHealthDisplay);
            _childPresenters.Add(_entitiesHealthDisplayPresenter);
        }
    }
}

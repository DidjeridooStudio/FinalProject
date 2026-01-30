using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.ResetProgressPopup;
using Assets._Project.Develop.Runtime.UI.Core.StartGamePopup;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuPopupService : PopupService
    {
        private readonly MainMenuUIRoot _uiRoot;

        private readonly MainMenuPresentersFactory _contextpresentersFactory;

        public MainMenuPopupService(ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory,
            MainMenuUIRoot uiRoot,
            MainMenuPresentersFactory contextpresentersFactory) : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
            _contextpresentersFactory = contextpresentersFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public StartGamePopupPresenter OpenStartGamePopup(Action closedCallback = null)
        {
            StartGamePopupView view = ViewsFactory.Create<StartGamePopupView>(ViewsIDs.StartGamePopup, PopupLayer);

            StartGamePopupPresenter popupPresenter = _contextpresentersFactory.CreateStartGamePopupPresenter(view);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }

        public ResetProgressPopupPresenter OpenResetProgress(Action closedCallback = null)
        {
            ResetProgressPopupView view = ViewsFactory.Create<ResetProgressPopupView>(ViewsIDs.ResetProgressPopup, PopupLayer);

            ResetProgressPopupPresenter popupPresenter = _contextpresentersFactory.CreateResetProgressPopupPresenter(view);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }
    }
}

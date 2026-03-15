using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup;
using Assets._Project.Develop.Runtime.UI.GamePlay.ResultsPopups;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayPopupService : PopupService
    {
        private readonly GameplayUIRoot _uiRoot;

        private readonly GameplayPresentersFactory _contextpresentersFactory;

        public GameplayPopupService(ViewsFactory viewsFactory,
            ProjectPresentersFactory presentersFactory,
            GameplayUIRoot uiRoot,
            GameplayPresentersFactory contextpresentersFactory) : base(viewsFactory, presentersFactory)
        {
            _uiRoot = uiRoot;
            _contextpresentersFactory = contextpresentersFactory;
        }

        protected override Transform PopupLayer => _uiRoot.PopupsLayer;

        public WinPopupPresenter OpenWinPopup(Action closedCallback = null)
        {
            WinPopupView view = ViewsFactory.Create<WinPopupView>(ViewsIDs.WinPopup, PopupLayer);

            WinPopupPresenter popupPresenter = _contextpresentersFactory.CreateWinPopupPresenter(view);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }

        public DefeatPopupPresenter OpenDefeatPopup(Action closedCallback = null)
        {
            DefeatPopupView view = ViewsFactory.Create<DefeatPopupView>(ViewsIDs.DefeatPopup, PopupLayer);

            DefeatPopupPresenter popupPresenter = _contextpresentersFactory.CreateDefeatPopupPresenter(view);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }

        public CheckProgressPopupPresenter OpenCheckProgressPopup(string userInput, Action closedCallback = null)
        {
            CheckProgressPopupView view = ViewsFactory.Create<CheckProgressPopupView>(ViewsIDs.CheckProgressPopup, PopupLayer);

            CheckProgressPopupPresenter popupPresenter = _contextpresentersFactory.CreateCheckProgressPopupPresenter(view, userInput);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }
    }
}

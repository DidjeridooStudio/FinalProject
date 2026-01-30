using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup;
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

        public CheckProgressPopupPresenter OpenCheckProgressPopup(string userInput, Action closedCallback = null)
        {
            CheckProgressPopupView view = ViewsFactory.Create<CheckProgressPopupView>(ViewsIDs.CheckProgressPopup, PopupLayer);

            CheckProgressPopupPresenter popupPresenter = _contextpresentersFactory.CreateCheckProgressPopupPresenter(view, userInput);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }
    }
}

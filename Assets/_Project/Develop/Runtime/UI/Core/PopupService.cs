using Assets._Project.Develop.Runtime.UI.Core.MessagePopup;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupService : IDisposable
    {
        protected readonly ViewsFactory ViewsFactory;
        private readonly ProjectPresentersFactory _presentersFactory;

        private readonly Dictionary<PopupPresenterBase, PopupInfo> _presenetToInfo = new Dictionary<PopupPresenterBase, PopupInfo>();

        protected PopupService(ViewsFactory viewsFactory, ProjectPresentersFactory presentersFactory)
        {
            ViewsFactory = viewsFactory;
            _presentersFactory = presentersFactory;
        }

        protected abstract Transform PopupLayer {  get; }

        #region Interface

        public void Dispose()
        {
            foreach (PopupPresenterBase popupPresenter in _presenetToInfo.Keys)
            {
                popupPresenter.CloseRequest -= ClosePopup;
                DisposeFor(popupPresenter);
            }

            _presenetToInfo.Clear();
        }

        #endregion

        public MessagePopupPresenter OpenMessagePopup(Action closedCallback = null)
        {
            MessagePopupView view = ViewsFactory.Create<MessagePopupView>(ViewsIDs.MessagePopup, PopupLayer);

            MessagePopupPresenter popupPresenter = _presentersFactory.CreateMessagePopupPresenter(view);

            OnPopupCreated(popupPresenter, view, closedCallback);

            return popupPresenter;
        }

        public void ClosePopup(PopupPresenterBase popupPresenter)
        {
            popupPresenter.CloseRequest -= ClosePopup;

            popupPresenter.Hide(() =>
            {
                _presenetToInfo[popupPresenter].ClosedCallback?.Invoke();

                DisposeFor(popupPresenter);
                _presenetToInfo.Remove(popupPresenter);
            });
        }

        protected void OnPopupCreated(PopupPresenterBase popupPresenter, PopupViewBase popupView, Action closedCallback = null)
        {
            _presenetToInfo.Add(popupPresenter, new PopupInfo(popupView, closedCallback));

            popupPresenter.Initialize();
            popupPresenter.Show();

            popupPresenter.CloseRequest += ClosePopup;
        }

        private void DisposeFor(PopupPresenterBase popupPresenter)
        {
            popupPresenter.Dispose();
            ViewsFactory.Release(_presenetToInfo[popupPresenter].PopupView);
        }

        private class PopupInfo
        {
            public PopupInfo(PopupViewBase popupView, Action closedCallback)
            {
                PopupView = popupView;
                ClosedCallback = closedCallback;
            }

            public PopupViewBase PopupView { get; }
            public Action ClosedCallback { get; }
        }
    }
}

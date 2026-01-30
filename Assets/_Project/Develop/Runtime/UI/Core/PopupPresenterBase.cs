using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupPresenterBase : ISubscribePresenter
    {
        public event Action<PopupPresenterBase> CloseRequest;

        protected readonly ICoroutinesPerformer _coroutinesPerformer;

        private Coroutine _currentProcess;

        protected PopupPresenterBase(ICoroutinesPerformer coroutinesPerformer)
        {
            _coroutinesPerformer = coroutinesPerformer;
        }

        protected abstract PopupViewBase PopupView { get; }

        #region Interface

        public virtual void Initialize()
        {
        }

        public virtual void Dispose()
        {
            KillCurrentProcess();

            PopupView.CloseRequest -= OnCloseRequest;
        }

        public virtual void Subscribe()
        {
        }

        public virtual void Unsubscribe()
        {
            PopupView.CloseRequest -= OnCloseRequest;
        }

        #endregion

        public void Show()
        {
            KillCurrentProcess();

            _currentProcess = _coroutinesPerformer?.StartPerform(ProcessShow());
        }

        public void Hide(Action callback = null)
        {
            KillCurrentProcess();

            _currentProcess = _coroutinesPerformer?.StartPerform(ProcessHide(callback));
        }

        protected virtual void OnPreShow()
        {
            PopupView.CloseRequest += OnCloseRequest;
        }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreHide()
        {
            PopupView.CloseRequest -= OnCloseRequest;
        }

        protected virtual void OnPostHide() { }

        protected void OnCloseRequest() => CloseRequest?.Invoke(this);

        private IEnumerator ProcessShow()
        {
            OnPreShow();

            yield return PopupView.Show().WaitForCompletion();

            OnPostShow();
        }

        private IEnumerator ProcessHide(Action callback)
        {
            OnPreHide();

            yield return PopupView.Hide().WaitForCompletion();

            OnPostHide();

            callback?.Invoke();
        }

        private void KillCurrentProcess()
        {
            if (_currentProcess != null)
                _coroutinesPerformer?.StopPerform(_currentProcess);
        }
    }
}

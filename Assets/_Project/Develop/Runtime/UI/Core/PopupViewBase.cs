using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core
{
    public abstract class PopupViewBase : MonoBehaviour, IShowableView
    {
        public event Action CloseRequest;

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Transform _body;
        [SerializeField] private Image _anticlicker;

        private Tween _currentAnimation;

        private void Awake()
        {
            _canvasGroup.alpha = 0;
        }

        public void OnCloseButtonClicked() => CloseRequest?.Invoke();

        #region Interface

        public Tween Show()
        {
            KillCurrentAnimation();

            OnPreShow();

            _canvasGroup.alpha = 1;

            Sequence animationSequence = DOTween.Sequence();

            animationSequence
                .Append(_anticlicker.DOFade(0.75f, 1).From(0))
                .Join(_body.DOScale(1, 0.5f).From(0).SetEase(Ease.OutBack));

            ModifyShowAnimation(animationSequence);

            _currentAnimation = animationSequence;

            animationSequence.OnComplete(OnPostShow);

            return _currentAnimation.SetUpdate(true).Play();
        }

        public Tween Hide()
        {
            KillCurrentAnimation();

            OnPreHide();

            _canvasGroup.alpha = 0;

            Sequence animationSequence = DOTween.Sequence();

            ModifyHideAnimation(animationSequence);

            _currentAnimation = animationSequence;

            animationSequence.OnComplete(OnPostHide);

            return _currentAnimation.SetUpdate(true).Play();
        }

        #endregion

        protected virtual void OnPreShow() { }

        protected virtual void OnPostShow() { }

        protected virtual void OnPreHide() { }

        protected virtual void OnPostHide() { }

        protected virtual void ModifyShowAnimation(Sequence sequence) { }
        protected virtual void ModifyHideAnimation(Sequence sequence) { }

        private void OnDestroy() => KillCurrentAnimation();

        private void KillCurrentAnimation() => _currentAnimation?.Kill();
    }
}

using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.UI.Core.MessagePopup
{
    public class MessagePopupPresenter : PopupPresenterBase
    {
        private readonly MessagePopupView _view;

        public MessagePopupPresenter(ICoroutinesPerformer coroutinesPerformer, MessagePopupView view) : base(coroutinesPerformer)
        {
            _view = view;
        }

        protected override PopupViewBase PopupView => _view;

        public MessagePopupView View => _view;

        public override void Dispose()
        {
            base.Dispose();

            _view.OKButtonClicked -= OnOKButtonClicked;
        }

        public override void Subscribe()
        {
            _view.OKButtonClicked += OnOKButtonClicked;
        }

        public override void Unsubscribe()
        {
            _view.OKButtonClicked -= OnOKButtonClicked;
        }

        protected override void OnPreShow()
        {
            base.OnPreShow();

            Subscribe();
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            Unsubscribe();
        }

        private void OnOKButtonClicked() => _view.OnCloseButtonClicked();
    }
}

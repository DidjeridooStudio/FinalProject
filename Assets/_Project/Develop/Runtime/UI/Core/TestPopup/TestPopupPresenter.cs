using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.UI.Core.TestPopup
{
    public class TestPopupPresenter : PopupPresenterBase
    {
        private readonly TestPopupView _testPopupView;

        public TestPopupPresenter(ICoroutinesPerformer coroutinesPerformer, TestPopupView testPopupView) : base(coroutinesPerformer)
        {
            _testPopupView = testPopupView;
        }

        protected override PopupViewBase PopupView => _testPopupView;
    }
}

using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.ResultsPopups
{
    public class DefeatPopupPresenter : PopupPresenterBase
    {
        private const string TitleName = "YOU LOOSE!";

        private readonly DefeatPopupView _popupView;
        private readonly ScenesSwitcherService _scenesSwitcherService;

        public DefeatPopupPresenter(ICoroutinesPerformer coroutinesPerformer, DefeatPopupView popupView,
            ScenesSwitcherService scenesSwitcherService) : base(coroutinesPerformer)
        {
            _popupView = popupView;
            _scenesSwitcherService = scenesSwitcherService;
        }

        protected override PopupViewBase PopupView => _popupView;

        public override void Initialize()
        {
            base.Initialize();

            _popupView.SetTitle(TitleName);

            _popupView.ContinueClicked += OnContinueClicked;
        }

        protected override void OnPreHide()
        {
            base.OnPreHide();

            _popupView.ContinueClicked -= OnContinueClicked;
        }

        public override void Dispose()
        {
            base.Dispose();

            _popupView.ContinueClicked -= OnContinueClicked;
        }

        private void OnContinueClicked()
        {
            _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
            OnCloseRequest();
        }
    }
}

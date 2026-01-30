using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup
{
    public class CheckProgressPopupPresenter : PopupPresenterBase
    {
        private readonly CheckProgressPopupView _view;
        private readonly GameplayCircleL3 _gameplayCircle;
        private readonly ScenesSwitcherService _scenesSwitcherService;
        private string _userString;

        public CheckProgressPopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            CheckProgressPopupView view,
            GameplayCircleL3 gameplayCircle,
            ScenesSwitcherService scenesSwitcherService,
            string userString) : base(coroutinesPerformer)
        {
            _view = view;
            _gameplayCircle = gameplayCircle;
            _scenesSwitcherService = scenesSwitcherService;
            _userString = userString;
        }

        protected override PopupViewBase PopupView => _view;

        public CheckProgressPopupView View => _view;

        public override void Initialize()
        {
            base.Initialize();

            string message = _gameplayCircle.ProcessUserInput(_userString);

            _view.SetText(message);
        }

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

        private void OnOKButtonClicked()
        {
            string sceneName = _gameplayCircle.SceneSwitchTo;

            GameplayInputArgs sceneArgs = null;

            if (sceneName == Scenes.Gameplay)
                sceneArgs = _gameplayCircle.InputArgs;

            _coroutinesPerformer?.StartPerform(_scenesSwitcherService.ProcessSwitchTo(sceneName, sceneArgs));
        }
    }
}

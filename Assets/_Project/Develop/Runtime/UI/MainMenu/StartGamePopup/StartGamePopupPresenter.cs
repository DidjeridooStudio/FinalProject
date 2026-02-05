using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Meta.Utilities;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;

namespace Assets._Project.Develop.Runtime.UI.Core.StartGamePopup
{
    public class StartGamePopupPresenter : PopupPresenterBase
    {
        private readonly StartGamePopupView _view;
        private readonly ModeSelectionService _modeSelectionService;

        public StartGamePopupPresenter(
            ICoroutinesPerformer coroutinesPerformer,
            StartGamePopupView view,
            ModeSelectionService modeSelectionService) : base(coroutinesPerformer)
        {
            _view = view;
            _modeSelectionService = modeSelectionService;
        }

        protected override PopupViewBase PopupView => _view;

        public override void Dispose()
        {
            base.Dispose();

            _view.NumbersModeButtonClicked -= OnNumbersModeButtonClicked;
            _view.LettersModeButtonClicked -= OnLettersModeButtonClicked;
        }

        public override void Subscribe()
        {
            _view.NumbersModeButtonClicked += OnNumbersModeButtonClicked;
            _view.LettersModeButtonClicked += OnLettersModeButtonClicked;
        }

        public override void Unsubscribe()
        {
            _view.NumbersModeButtonClicked -= OnNumbersModeButtonClicked;
            _view.LettersModeButtonClicked -= OnLettersModeButtonClicked;
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

        private void OnNumbersModeButtonClicked() => _modeSelectionService.Select(ModeTypes.Numbers);

        private void OnLettersModeButtonClicked() => _modeSelectionService.Select(ModeTypes.Letters);
    }
}

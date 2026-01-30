using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.UI.Core;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayScreenPresenter : IPresenter
    {
        private readonly GameplayScreenView _screenView;
        private readonly GameplayCircleL3 _gameplayCircle;
        private readonly GameplayPopupService _gameplayPopupService;

        public GameplayScreenPresenter(GameplayScreenView screeView, GameplayCircleL3 gameplayCircle, GameplayPopupService popupService)
        {
            _screenView = screeView;
            _gameplayCircle = gameplayCircle;
            _gameplayPopupService = popupService;
        }

        #region Interface

        public void Initialize()
        {
            _screenView.CheckButtonClicked += OnCheckButtonClicked;
            _gameplayCircle.RandomStringSetted += OnRandomStringSetted;
        }

        public void Dispose()
        {
            _screenView.CheckButtonClicked -= OnCheckButtonClicked;
            _gameplayCircle.RandomStringSetted -= OnRandomStringSetted;
        }

        #endregion

        private void OnCheckButtonClicked(string userInput) => _gameplayPopupService.OpenCheckProgressPopup(userInput);

        private void OnRandomStringSetted() => _screenView.SetRandomString(_gameplayCircle.RandomString);
    }
}

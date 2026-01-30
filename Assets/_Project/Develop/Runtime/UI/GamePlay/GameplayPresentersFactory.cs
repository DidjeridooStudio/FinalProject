using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup;
using Assets._Project.Develop.Runtime.UI.Core.MessagePopup;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(view, _container.Resolve<GameplayCircleL3>(), _container.Resolve<GameplayPopupService>());
        }

        public CheckProgressPopupPresenter CreateCheckProgressPopupPresenter(CheckProgressPopupView view, string userInput)
        {
            return new CheckProgressPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<GameplayCircleL3>(),
                _container.Resolve<ScenesSwitcherService>(),
                userInput);
        }
    }
}

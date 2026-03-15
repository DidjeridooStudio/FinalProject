using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup;
using Assets._Project.Develop.Runtime.UI.GamePlay.HealthPresenter;
using Assets._Project.Develop.Runtime.UI.GamePlay.ResultsPopups;
using Assets._Project.Develop.Runtime.UI.GamePlay.Stages;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayPresentersFactory
    {
        private readonly DIContainer _container;

        public EntitiesHealthDisplayPresenter CreateEntitiesHealthDisplayPresenter(EntitiesHealthDisplay view)
        {
            return new EntitiesHealthDisplayPresenter(
                _container.Resolve<EntitiesLifeContext>(),
                view,
                this,
                _container.Resolve<ViewsFactory>());
        }

        public EntityHealthPresenter CreateEntityHealthPresenter(Entity entity, BarWithText view)
        {
            return new EntityHealthPresenter(view, entity);
        }

        public GameplayPresentersFactory(DIContainer container)
        {
            _container = container;
        }

        public StagePresenter CreateStagePresenter(IconTextView view)
        {
            return new StagePresenter(view, _container.Resolve<StageProviderService>());
        }

        public WinPopupPresenter CreateWinPopupPresenter(WinPopupView view)
        {
            return new WinPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ScenesSwitcherService>());
        }

        public DefeatPopupPresenter CreateDefeatPopupPresenter(DefeatPopupView view)
        {
            return new DefeatPopupPresenter(
                _container.Resolve<ICoroutinesPerformer>(),
                view,
                _container.Resolve<ScenesSwitcherService>());
        }

        public GameplayScreenPresenter CreateGameplayScreenPresenter(GameplayScreenView view)
        {
            return new GameplayScreenPresenter(view, _container.Resolve<GameplayPresentersFactory>(), _container.Resolve<ProjectPresentersFactory>());
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

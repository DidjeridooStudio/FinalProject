using Assets._Project.Develop.Runtime.UI.GamePlay;
using Assets._Project.Develop.Runtime.UI.GamePlay.PreparationStatePopup;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class PreparationState : State, IUpdatebableState
    {
        private readonly GameplayPopupService _popupService;
        private PreparationStatePopupPresenter _preparationStatePopupPresenter;

        public PreparationState(GameplayPopupService popupService)
        {
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            _preparationStatePopupPresenter = _popupService.OpenPreparationStatePopup();
        }

        public void Update(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            base.Exit();

            _popupService.ClosePopup(_preparationStatePopupPresenter);
        }
    }
}

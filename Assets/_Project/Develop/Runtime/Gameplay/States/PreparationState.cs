using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class PreparationState : State, IUpdatebableState
    {
        private readonly PreparationTriggerService _triggerService;

        public PreparationState(PreparationTriggerService triggerService)
        {
            _triggerService = triggerService;
        }

        public override void Enter()
        {
            base.Enter();
        }

        public void Update(float deltaTime)
        {
            
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}

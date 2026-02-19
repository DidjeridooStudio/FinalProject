using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class AttackOnMouseAttackState : State, IUpdatebableState
    {
        private ReactiveEvent _attackRequest;
        private IInputService _inputService;

        public AttackOnMouseAttackState(Entity entity, IInputService inputService)
        {
            _attackRequest = entity.StartAttackRequest;
            _inputService = inputService;
        }

        public void Update(float deltaTime)
        {
            if(_inputService.LeftMouseButtonClicked)
                _attackRequest.Invoke();
        }
    }
}

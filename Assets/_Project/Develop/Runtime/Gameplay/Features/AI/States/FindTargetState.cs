using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class FindTargetState : State, IUpdatebableState
    {
        private ITargetSelector _targetSelector;
        private EntitiesLifeContext _entitiesLifeContext;
        private ReactiveVariable<Entity> _currentTarget;

        public FindTargetState(ITargetSelector targetSelector, EntitiesLifeContext entitiesLifeContext, Entity entity)
        {
            _targetSelector = targetSelector;
            _entitiesLifeContext = entitiesLifeContext;
            _currentTarget = entity.CurrentTarget;
        }

        public void Update(float deltaTime)
        {
            _currentTarget.Value = _targetSelector.SelectTargetFrom(_entitiesLifeContext.Entities);
        }
    }
}

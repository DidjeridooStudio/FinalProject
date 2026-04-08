using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    internal class AttackTriggerOnBodyContactState : State, IUpdatebableState
    {
        private ReactiveEvent _attackRequest;
        private Buffer<Entity> _contacts;

        public AttackTriggerOnBodyContactState(Entity entity)
        {
            _attackRequest = entity.StartAttackRequest;
            _contacts = entity.ContactsEntitiesBuffer;
        }

        public void Update(float deltaTime)
        {
            if(_contacts.Count > 0)
                _attackRequest.Invoke();
        }
    }
}

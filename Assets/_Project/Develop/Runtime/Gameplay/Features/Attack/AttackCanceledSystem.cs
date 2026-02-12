using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackCanceledSystem : IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _attackCanceledEvent;
        private ReactiveVariable<bool> _inAttackProcess;
        private ICompositeCondition _mustCancelAttack;

        #region Interface

        public void OnInit(Entity entity)
        {
            _attackCanceledEvent = entity.AttackCanceledEvent;
            _inAttackProcess = entity.InAttackProcess;
            _mustCancelAttack = entity.MustCancelAttack;
        }

        public void OnUpdate(float deltatime)
        {
            if(_inAttackProcess.Value == false)
                return;

            if (_mustCancelAttack.Evaluate())
            {
                _inAttackProcess.Value = false;
                _attackCanceledEvent.Invoke();
            }
        }

        #endregion
    }
}

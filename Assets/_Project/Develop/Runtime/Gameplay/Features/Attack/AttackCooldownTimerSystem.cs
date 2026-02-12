using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Attack
{
    public class AttackCooldownTimerSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _inAttackCooldown;
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;
        private ReactiveEvent _endAttackEvent;

        private IDisposable _endAttackEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _inAttackCooldown = entity.InAttackCooldown;
            _initialTime = entity.AttackCooldownInitialTime;
            _currentTime = entity.AttackCooldownCurrentTime;
            _endAttackEvent = entity.EndAttackEvent;

            _endAttackEventDisposable = _endAttackEvent.Subcribe(OnEndAttack);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inAttackCooldown.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
                _inAttackCooldown.Value = false;
        }

        public void OnDispose()
        {
            _endAttackEventDisposable.Dispose();
        }

        #endregion

        private void OnEndAttack()
        {
            _currentTime.Value = _initialTime.Value;
            _inAttackCooldown.Value = true;
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;
    }
}

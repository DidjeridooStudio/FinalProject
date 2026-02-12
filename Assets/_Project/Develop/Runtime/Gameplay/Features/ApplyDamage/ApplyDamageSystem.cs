using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage
{
    public class ApplyDamageSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveEvent<float> _damageRequest;
        private ReactiveEvent<float> _damageEvent;
        private ReactiveVariable<float> _health;
        private ICompositeCondition _canApplyDamage;

        private IDisposable _requestDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _damageRequest = entity.TakeDamageRequest;
            _damageEvent = entity.TakeDamageEvent;
            _health = entity.CurrentHealth;
            _canApplyDamage = entity.CanApplyDamage;

            _requestDisposable = _damageRequest.Subcribe(OnDamageRequest);
        }

        public void OnUpdate(float deltaTime)
        {
            
        }

        public void OnDispose()
        {
            _requestDisposable.Dispose();
        }

        #endregion

        private void OnDamageRequest(float damage)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (_canApplyDamage.Evaluate() == false)
                return;

            _health.Value = Math.Max(_health.Value - damage, 0);

            _damageEvent.Invoke(damage);
        }
    }
}

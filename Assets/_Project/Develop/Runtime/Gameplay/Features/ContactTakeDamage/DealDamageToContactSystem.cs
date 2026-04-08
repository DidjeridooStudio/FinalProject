using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage
{
    public class DealDamageToContactSystem : IInitializableSystem, IDisposableSystem
    {
        private Entity _entity;
        private Buffer<Entity> _contacts;
        private ReactiveVariable<float> _damage;

        private ReactiveEvent _attackDelayEndEvent;
        private IDisposable _attackDelayEndDisposable;

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _contacts = entity.ContactsEntitiesBuffer;
            _damage = entity.BodyContactDamage;

            _attackDelayEndEvent = entity.AttackDelayEndEvent;
            _attackDelayEndDisposable = _attackDelayEndEvent.Subcribe(OnAttackDelayEnd);
        }

        public void OnDispose()
        {
            _attackDelayEndDisposable.Dispose();
        }

        private void OnAttackDelayEnd()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];
                EntitiesHepler.TryTakeDamageFrom(_entity, contactEntity, _damage.Value);
            }
        }
    }
}

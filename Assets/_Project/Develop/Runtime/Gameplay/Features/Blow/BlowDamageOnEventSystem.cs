using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowDamageOnEventSystem : IInitializableSystem, IDisposableSystem
    {
        private Entity _entity;
        private ReactiveVariable<float> _blowDamage;
        private Buffer<Entity> _contacts;
        private ReactiveEvent _blowContactsDetectingEvent;

        private IDisposable _blowContactsDetectingEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _blowDamage = entity.BlowDamage;
            _contacts = entity.ContactsEntitiesBuffer;
            _blowContactsDetectingEvent = entity.BlowContactsDetectingEvent;

            _blowContactsDetectingEventDisposable = _blowContactsDetectingEvent.Subcribe(OnBlowContactsDetecting);
        }

        public void OnDispose()
        {
            _blowContactsDetectingEventDisposable.Dispose();
        }

        #endregion

        private void OnBlowContactsDetecting()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                EntitiesHepler.TryTakeDamageFrom(_entity, contactEntity, _blowDamage.Value);
            }
        }
    }
}

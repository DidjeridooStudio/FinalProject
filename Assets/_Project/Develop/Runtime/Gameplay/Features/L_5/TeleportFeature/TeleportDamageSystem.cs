using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature
{
    public class TeleportDamageSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _teleportationDamage;
        private Buffer<Entity> _contacts;
        private ReactiveEvent _teleportContactsDetectingEvent;

        private IDisposable _teleportContactsDetectingEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _teleportationDamage = entity.TeleportationDamage;
            _contacts = entity.ContactsEntitiesBuffer;
            _teleportContactsDetectingEvent = entity.TeleportContactsDetectingEvent;

            _teleportContactsDetectingEventDisposable = _teleportContactsDetectingEvent.Subcribe(OnTeleportContactsDetecting);
        }

        public void OnDispose()
        {
            _teleportContactsDetectingEventDisposable.Dispose();
        }

        #endregion

        private void OnTeleportContactsDetecting()
        {
            for (int i = 0; i < _contacts.Count; i++)
            {
                Entity contactEntity = _contacts.Items[i];

                if (contactEntity.HasComponent<TakeDamageRequest>())
                    contactEntity.TakeDamageRequest.Invoke(_teleportationDamage.Value);
            }
        }
    }
}

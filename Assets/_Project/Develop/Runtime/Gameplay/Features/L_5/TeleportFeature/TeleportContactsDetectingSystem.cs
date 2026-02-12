using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature
{
    public class TeleportContactsDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _layerMask;
        private ReactiveVariable<float> _teleportationDamageRadius;
        private Transform _transform;
        private CapsuleCollider _body;
        private ReactiveEvent _teleportCastEvent;
        private ReactiveEvent _teleportContactsDetectingEvent;

        private IDisposable _teleportCastEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactsColliderBuffer;
            _layerMask = entity.ContactsDetectingMask;
            _teleportationDamageRadius = entity.TeleportationDamageRadius;
            _transform = entity.Transform;
            _body = entity.BodyCollider;
            _teleportCastEvent = entity.TeleportCastEvent;
            _teleportContactsDetectingEvent = entity.TeleportContactsDetectingEvent;

            _teleportCastEventDisposable = _teleportCastEvent.Subcribe(OnTeleportCast);
        }

        public void OnDispose()
        {
            _teleportCastEventDisposable.Dispose();
        }

        #endregion

        private void OnTeleportCast()
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                _transform.position,
                _teleportationDamageRadius.Value,
                _contacts.Items,
                _layerMask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

            _teleportContactsDetectingEvent.Invoke();
        }

        private void RemoveSelfFromContacts()
        {
            int indexToRemove = -1;

            for (int i = 0; i < _contacts.Count; i++)
            {
                if (_contacts.Items[i] == _body)
                {
                    indexToRemove = i;
                    break;
                }
            }

            if (indexToRemove >= 0)
            {
                for (int i = indexToRemove; i < _contacts.Count - 1; ++i)
                    _contacts.Items[i] = _contacts.Items[i + 1];

                _contacts.Count--;
            }
        }
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowContactsDetectingSystem : IInitializableSystem, IDisposableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _layerMask;
        private ReactiveVariable<float> _blowRadius;
        private CapsuleCollider _body;
        private ReactiveEvent<Vector3> _blowEvent;
        private ReactiveEvent _blowContactsDetectingEvent;

        private IDisposable _blowEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactsColliderBuffer;
            _layerMask = entity.ContactsDetectingMask;
            _blowRadius = entity.BlowRadius;
            _body = entity.BodyCollider;
            _blowEvent = entity.BlowEvent;
            _blowContactsDetectingEvent = entity.BlowContactsDetectingEvent;

            _blowEventDisposable = _blowEvent.Subcribe(OnBlow);
        }

        public void OnDispose()
        {
            _blowEventDisposable.Dispose();
        }

        #endregion

        private void OnBlow(Vector3 position)
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                position,
                _blowRadius.Value,
                _contacts.Items,
                _layerMask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

            _blowContactsDetectingEvent.Invoke();
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

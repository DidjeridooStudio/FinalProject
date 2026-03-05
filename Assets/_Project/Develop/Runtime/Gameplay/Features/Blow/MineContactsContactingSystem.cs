using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class MineDetectingSystem : IInitializableSystem, IUpdatableSystem
    {
        private Buffer<Collider> _contacts;
        private LayerMask _layerMask;
        private ReactiveVariable<float> _blowRadius;
        private CapsuleCollider _body;
        private Transform _bodyTransform;
        private ReactiveEvent<Vector3> _blowRequest;

        #region Interface

        public void OnInit(Entity entity)
        {
            _contacts = entity.ContactsColliderBuffer;
            _layerMask = entity.ContactsDetectingMask;
            _blowRadius = entity.BlowRadius;
            _body = entity.BodyCollider;
            _blowRequest = entity.BlowRequest;
            _bodyTransform = entity.Transform;
        }

        #endregion

        public void OnUpdate(float deltaTime)
        {
            _contacts.Count = Physics.OverlapSphereNonAlloc(
                _bodyTransform.position,
                _blowRadius.Value,
                _contacts.Items,
                _layerMask,
                QueryTriggerInteraction.Ignore);

            RemoveSelfFromContacts();

            if (_contacts.Count > 0)
                _blowRequest?.Invoke(_bodyTransform.position);
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

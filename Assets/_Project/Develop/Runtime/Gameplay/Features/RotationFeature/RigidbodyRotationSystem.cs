using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeadZone = 0.05f;

        private ReactiveVariable<Vector3> _rotateDirection;
        private ReactiveVariable<float> _rotateSpeed;
        private Rigidbody _rigidbody;
        private ICompositeCondition _canRotate;

        #region Interface

        public void OnInit(Entity entity)
        {
            _rotateDirection = entity.RotateDirection;
            _rotateSpeed = entity.RotateSpeed;
            _rigidbody = entity.Rigidbody;
            _canRotate = entity.CanRotate;

            if (_rotateDirection.Value != Vector3.zero)
                _rigidbody.transform.rotation = Quaternion.LookRotation(_rotateDirection.Value.normalized);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_rotateDirection.Value.magnitude < DeadZone)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotateDirection.Value.normalized);

            float step = _rotateSpeed.Value * deltaTime;

            _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step));
        }

        #endregion
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RigidbodyRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeadZone = 0.05f;

        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<float> _rotateSpeed;
        private Rigidbody _rigidbody;

        #region Interface

        public void OnInit(Entity entity)
        {
            _moveDirection = entity.MoveDirection;
            _rotateSpeed = entity.RotateSpeed;
            _rigidbody = entity.Rigidbody;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_moveDirection.Value.magnitude < DeadZone)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_moveDirection.Value.normalized * deltaTime);

            float step = _rotateSpeed.Value * deltaTime;

            _rigidbody.MoveRotation(Quaternion.RotateTowards(_rigidbody.rotation, lookRotation, step));
        }

        #endregion
    }
}

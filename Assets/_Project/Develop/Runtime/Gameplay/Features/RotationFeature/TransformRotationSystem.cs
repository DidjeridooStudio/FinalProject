using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class TransformRotationSystem : IInitializableSystem, IUpdatableSystem
    {
        private const float DeadZone = 0.05f;

        private ReactiveVariable<Vector3> _rotateDirection;
        private ReactiveVariable<float> _rotateSpeed;
        private Transform _transform;
        private ICompositeCondition _canRotate;

        #region Interface

        public void OnInit(Entity entity)
        {
            _rotateDirection = entity.RotateDirection;
            _rotateSpeed = entity.RotateSpeed;
            _transform = entity.Transform;
            _canRotate = entity.CanRotate;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_canRotate.Evaluate() == false)
                return;

            if (_rotateDirection.Value.magnitude < DeadZone)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_rotateDirection.Value.normalized);

            float step = _rotateSpeed.Value * deltaTime;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }

        #endregion
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class RotateToTargetState : State, IUpdatebableState
    {
        private ReactiveVariable<Vector3> _rotateDirection;
        private ReactiveVariable<Entity> _currentTarget;
        private Transform _transform;

        public RotateToTargetState(Entity entity)
        {
            _rotateDirection = entity.RotateDirection;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value != null)
                _rotateDirection.Value = (_currentTarget.Value.Transform.position - _transform.position).normalized;
        }
    }
}

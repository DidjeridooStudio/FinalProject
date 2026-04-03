using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class MoveToTargetState : State, IUpdatebableState
    {
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<Vector3> _rotateDirection;
        private Transform _source;
        private Transform _target;

        public MoveToTargetState(Entity entity, Transform target)
        {
            _moveDirection = entity.MoveDirection;
            _rotateDirection = entity.RotateDirection;
            _source = entity.Transform;
            _target = target;
        }

        public void Update(float deltaTime)
        {
            _moveDirection.Value = _target.position - _source.position;
            _rotateDirection.Value = _moveDirection.Value;
        }

        public override void Exit()
        {
            base.Exit();

            _moveDirection.Value = Vector3.zero;
        }
    }
}

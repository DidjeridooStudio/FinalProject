using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerInputMovementState : State, IUpdatebableState
    {
        private IInputService _inputService;
        private ReactiveVariable<Vector3> _moveDirection;
        private ReactiveVariable<Vector3> _rotateDirection;

        public PlayerInputMovementState(Entity entity, IInputService inputService)
        {
            _moveDirection = entity.MoveDirection;
            _rotateDirection = entity.RotateDirection;
            _inputService = inputService;
        }

        public void Update(float deltaTime)
        {
            _moveDirection.Value = _inputService.Direction;
            _rotateDirection.Value = _inputService.Direction;
        }

        public override void Exit()
        {
            base.Exit();

            _moveDirection.Value = Vector3.zero;
        }
    }
}

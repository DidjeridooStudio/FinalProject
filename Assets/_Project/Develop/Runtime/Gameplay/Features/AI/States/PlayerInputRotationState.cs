using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerInputRotationState : State, IUpdatebableState
    {
        private IInputService _inputService;
        private ReactiveVariable<Vector3> _rotateDirection;
        private Transform _transform;

        public PlayerInputRotationState(Entity entity, IInputService inputService)
        {
            _rotateDirection = entity.RotateDirection;
            _inputService = inputService;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            Vector3 directionToMouse = (_inputService.MousePosition - _transform.position).normalized;

            _rotateDirection.Value = new Vector3(directionToMouse.x, 0, directionToMouse.z);
        }
    }
}

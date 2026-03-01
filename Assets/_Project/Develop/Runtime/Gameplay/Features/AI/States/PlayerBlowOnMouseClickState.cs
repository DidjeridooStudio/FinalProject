using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class PlayerBlowOnMouseClickState : State, IUpdatebableState
    {
        private IInputService _inputService;
        private ReactiveEvent<Vector3> _blowRequest;
        private Transform _transform;

        public PlayerBlowOnMouseClickState(Entity entity, IInputService inputService)
        {
            _inputService = inputService;
            _blowRequest = entity.BlowRequest;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.LeftMouseButtonClicked)
            {
                Ray ray = Camera.main.ScreenPointToRay(_inputService.MousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    _transform.position = hitInfo.point;
                    _blowRequest.Invoke(hitInfo.point);
                }
            }
        }
    }
}

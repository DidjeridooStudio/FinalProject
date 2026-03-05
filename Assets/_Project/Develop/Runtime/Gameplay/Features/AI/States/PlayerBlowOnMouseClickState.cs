using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
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
        private RaycastOnMousePositionService _raycastOnMousePositionService;

        public PlayerBlowOnMouseClickState(Entity entity, IInputService inputService, RaycastOnMousePositionService raycastOnMousePositionService)
        {
            _inputService = inputService;
            _blowRequest = entity.BlowRequest;
            _transform = entity.Transform;
            _raycastOnMousePositionService = raycastOnMousePositionService;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.LeftMouseButtonClicked)
            {
                Vector3 raycastHitPoint = _raycastOnMousePositionService.RaycastHitPoint();
                if (raycastHitPoint != Vector3.zero)
                {
                    _transform.position = raycastHitPoint;
                    _blowRequest.Invoke(raycastHitPoint);
                }
            }
        }
    }
}

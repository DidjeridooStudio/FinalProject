using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class RaycastOnMousePositionService
    {
        private IInputService _inputService;

        public RaycastOnMousePositionService(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Vector3 RaycastHitPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(_inputService.MousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                return hitInfo.point;
            }

            return Vector3.zero;
        }
    }
}

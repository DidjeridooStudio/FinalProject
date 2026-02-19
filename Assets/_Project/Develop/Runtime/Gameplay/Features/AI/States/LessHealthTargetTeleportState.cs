using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class LessHealthTargetTeleportState : State, IUpdatebableState
    {
        private ReactiveEvent<float, Vector3> _teleportCastRequest;
        private ReactiveVariable<float> _teleportationRadius;
        private ReactiveVariable<Entity> _currentTarget;
        private Transform _transform;

        private float _energyForCast;

        private float _cooldownBetweenTeleporting;
        private float _time;

        public LessHealthTargetTeleportState(Entity entity, float energyForCast, float cooldownBetweenTeleporting)
        {
            _teleportCastRequest = entity.TeleportCastRequest;
            _teleportationRadius = entity.TeleportationRadius;
            _energyForCast = energyForCast;
            _currentTarget = entity.CurrentTarget;
            _transform = entity.Transform;
            _cooldownBetweenTeleporting = cooldownBetweenTeleporting;
        }

        public void Update(float deltaTime)
        {
            if (_currentTarget.Value == null)
                return;

            _time += deltaTime;

            if (_time >= _cooldownBetweenTeleporting)
            {
                _teleportCastRequest.Invoke(_energyForCast, GenerateNearestPositionToTarget());
                _time = 0;
            }
        }

        private Vector3 GenerateNearestPositionToTarget()
        {
            Vector3 directionToTarget = (_currentTarget.Value.Transform.position - _transform.position).normalized;
            return directionToTarget * _teleportationRadius.Value;
        }
    }
}

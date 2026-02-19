using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class RandomTeleportState : State, IUpdatebableState
    {
        private ReactiveEvent<float, Vector3> _teleportCastRequest;
        private ReactiveVariable<float> _teleportationRadius;

        private float _energyForCast;

        private float _cooldownBetweenTeleporting;
        private float _time;

        public RandomTeleportState(Entity entity, float cooldownBetweenTeleporting, float energyForCast)
        {
            _teleportCastRequest = entity.TeleportCastRequest;
            _teleportationRadius = entity.TeleportationRadius;
            _cooldownBetweenTeleporting = cooldownBetweenTeleporting;
            _energyForCast = energyForCast;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _cooldownBetweenTeleporting)
            {
                _teleportCastRequest.Invoke(_energyForCast, GenerateRandomPosition());
                _time = 0;
            }
        }

        private Vector3 GenerateRandomPosition()
        {
            Vector2 randomVector2 = Random.insideUnitCircle * _teleportationRadius.Value;
            return new Vector3(randomVector2.x, 0, randomVector2.y);
        }
    }
}

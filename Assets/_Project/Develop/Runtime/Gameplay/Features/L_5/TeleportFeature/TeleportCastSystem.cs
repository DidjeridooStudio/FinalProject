using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature
{
    public class TeleportCastSystem : IInitializableSystem
    {
        private ReactiveVariable<float> _teleportationRadius;
        private ReactiveEvent<float> _teleportCastRequest;
        private ReactiveEvent _teleportCastEvent;
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<bool> _inEnergyRefill;
        private Transform _transform;

        private IDisposable _castSpellRequestDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _teleportationRadius = entity.TeleportationRadius;
            _teleportCastRequest = entity.TeleportCastRequest;
            _teleportCastEvent = entity.TeleportCastEvent;
            _currentEnergy = entity.CurrentEnergy;
            _inEnergyRefill = entity.InEnergyRefillProcess;
            _transform = entity.Transform;

            _castSpellRequestDisposable = _teleportCastRequest.Subcribe(OnTeleportCastRequest);
        }

        public void OnDispose()
        {
            _castSpellRequestDisposable.Dispose();
        }

        #endregion

        private void OnTeleportCastRequest(float energy)
        {
            if (_currentEnergy.Value >= energy)
            {
                _currentEnergy.Value -= energy;
                _inEnergyRefill.Value = true;

                TeleportEntity();

                _teleportCastEvent.Invoke();
            }
            else
            {
                Debug.Log("Недостаточно маны");
            }
        }

        private void TeleportEntity()
        {
            Vector2 randomVector2 = Random.insideUnitCircle * _teleportationRadius.Value;
            _transform.position = _transform.position + new Vector3(randomVector2.x, 0, randomVector2.y);
        }
    }
}

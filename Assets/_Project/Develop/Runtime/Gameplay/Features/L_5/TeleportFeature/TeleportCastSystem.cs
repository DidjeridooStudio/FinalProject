using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature
{
    public class TeleportCastSystem : IInitializableSystem
    {
        private ReactiveEvent<float, Vector3> _teleportCastRequest;
        private ReactiveEvent _teleportCastEvent;
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<bool> _inEnergyRefill;
        private Transform _transform;

        private IDisposable _castSpellRequestDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
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

        private void OnTeleportCastRequest(float energy, Vector3 position)
        {
            if (_currentEnergy.Value >= energy)
            {
                _currentEnergy.Value -= energy;
                _inEnergyRefill.Value = true;

                TeleportEntity(position);

                _teleportCastEvent.Invoke();
            }
            else
            {
                Debug.Log("Недостаточно маны");
            }
        }

        private void TeleportEntity(Vector3 position)
        {
            _transform.position = _transform.position + position;
        }
    }
}

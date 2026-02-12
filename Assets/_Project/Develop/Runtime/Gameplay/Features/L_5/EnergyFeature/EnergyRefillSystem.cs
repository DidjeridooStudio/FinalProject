using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature
{
    public class EnergyRefillSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private ReactiveVariable<float> _initialTime;
        private ReactiveVariable<float> _currentTime;
        private ReactiveVariable<float> _currentEnergy;
        private ReactiveVariable<float> _maxEnergy;

        private ReactiveVariable<bool> _inEnergyRefill;

        private IDisposable _inEnergyRefillChangedDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _currentEnergy = entity.CurrentEnergy;
            _maxEnergy = entity.MaxEnergy;
            _initialTime = entity.EnergyRefillProcessInitialTime;
            _currentTime = entity.EnergyRefillProcessCurrentTime;
            _inEnergyRefill = entity.InEnergyRefillProcess;

            _inEnergyRefillChangedDisposable = _inEnergyRefill.Subcribe(OnInEnergyRefillChanged);
        }

        public void OnUpdate(float deltaTime)
        {
            if (_inEnergyRefill.Value == false)
                return;

            _currentTime.Value -= deltaTime;

            if (CooldownIsOver())
            {
                _currentEnergy.Value = Math.Min(_currentEnergy.Value + _maxEnergy.Value * 0.1f, _maxEnergy.Value);
                SetCooldown();
                Debug.Log("Текущая энергия " + _currentEnergy.Value);
            }

            if (_currentEnergy.Value == _maxEnergy.Value)
                _inEnergyRefill.Value = false;
        }

        public void OnDispose()
        {
            _inEnergyRefillChangedDisposable.Dispose();
        }

        #endregion

        private void OnInEnergyRefillChanged(bool arg1, bool inEnergyRefill)
        {
            if (inEnergyRefill)
                SetCooldown();
        }

        private bool CooldownIsOver() => _currentTime.Value <= 0;

        private void SetCooldown() => _currentTime.Value = _initialTime.Value;
    }
}

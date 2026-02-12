using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle
{
    public class DisableCollidersOnDeathSystem : IInitializableSystem, IUpdatableSystem, IDisposableSystem
    {
        private List<Collider> _colliders;
        private ReactiveVariable<bool> _isDead;

        private IDisposable _isDeadChangedDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _colliders = entity.DisableCollidersOnDeath;

            _isDeadChangedDisposable = _isDead.Subcribe(OnIsDeadChanged);
        }

        public void OnUpdate(float deltaTime)
        {
  
        }

        public void OnDispose()
        {
            _isDeadChangedDisposable.Dispose();
        }

        #endregion

        private void OnIsDeadChanged(bool arg1, bool isDead)
        {
            if (isDead)
                foreach (Collider collider in _colliders)
                    collider.enabled = false;
        }

    }
}

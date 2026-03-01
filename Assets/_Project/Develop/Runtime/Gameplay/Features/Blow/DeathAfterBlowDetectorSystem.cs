using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public  class DeathAfterBlowDetectorSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ReactiveEvent<Vector3> _blowEvent;

        private IDisposable _teleportCastEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _blowEvent = entity.BlowEvent;

            _teleportCastEventDisposable = _blowEvent.Subcribe(OnBlow);
        }

        public void OnDispose()
        {
            _teleportCastEventDisposable.Dispose();
        }

        #endregion

        private void OnBlow(Vector3 position)
        {
            _isDead.Value = true;
        }
    }
}

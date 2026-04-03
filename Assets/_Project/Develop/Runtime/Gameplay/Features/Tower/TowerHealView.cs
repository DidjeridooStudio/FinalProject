using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class TowerHealView : EntityView
    {
        [SerializeField] private ParticleSystem _healEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private IReadOnlyEvent _towerHealEvent;

        private IDisposable _towerHealEventDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _towerHealEvent = entity.TowerHealEvent;
            _towerHealEventDisposable = _towerHealEvent.Subcribe(OnTowerHeal);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);
            _towerHealEventDisposable.Dispose();
        }

        private void OnTowerHeal() => Instantiate(_healEffectPrefab, _effectSpawnPoint.position, Quaternion.identity);
    }
}

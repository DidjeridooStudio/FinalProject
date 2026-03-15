using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowEffectView : EntityView
    {
        [SerializeField] private ParticleSystem _blowEffectPrefab;
        [SerializeField] private Transform _effectSpawnPoint;

        private IReadOnlyEvent<Vector3> _blowEvent;

        private IDisposable _blowEventDisposable;

        protected override void OnEntityStartedWork(Entity entity)
        {
            _blowEvent = entity.BlowEvent;
            _blowEventDisposable = _blowEvent.Subcribe(OnBlow);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);
            _blowEventDisposable.Dispose();
        }

        private void OnBlow(Vector3 position) => Instantiate(_blowEffectPrefab, _effectSpawnPoint.position, Quaternion.identity);
    }
}

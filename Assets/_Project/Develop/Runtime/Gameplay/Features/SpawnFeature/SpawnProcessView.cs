using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.SpawnFeature
{
    [RequireComponent(typeof(Animator))]
    public class SpawnProcessView : EntityView
    {
        private readonly int SpawnProcessKey = Animator.StringToHash("InSpawnProcess");

        [SerializeField] private Animator _animator;
        [SerializeField] private ParticleSystem _spawnEffectPrefab;

        private Transform _entityTransform;
        private IReadOnlyVariable<bool> _inSpawnProcess;

        private IDisposable _inSpawnProcessChangedDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

        protected override void OnEntityStartedWork(Entity entity)
        {
            _inSpawnProcess = entity.InSpawnProcess;
            _entityTransform = entity.Transform;

            _inSpawnProcessChangedDisposable = _inSpawnProcess.Subcribe(OnSpawnProcessChanged);
            UpdateSpawnProcessKey(_inSpawnProcess.Value);
        }

        public override void Cleanup(Entity entity)
        {
            base.Cleanup(entity);
            _inSpawnProcessChangedDisposable.Dispose();
        }

        private void OnSpawnProcessChanged(bool oldValue, bool newValue) => UpdateSpawnProcessKey(newValue);

        private void UpdateSpawnProcessKey(bool value)
        {
            _animator.SetBool(SpawnProcessKey, value);

            if (value)
                Instantiate(_spawnEffectPrefab, _entityTransform.position, _spawnEffectPrefab.transform.rotation, null);
        }
    }
}

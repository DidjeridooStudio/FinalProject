using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    [RequireComponent(typeof(Animator))]
    public class BlowView : EntityView
    {
        private readonly int IsBlowingKey = Animator.StringToHash("IsBlowing");

        [SerializeField] private Animator _animator;

        private IReadOnlyEvent<Vector3> _blowEvent;

        private IDisposable _blowEventDisposable;

        private void OnValidate()
        {
            _animator ??= GetComponent<Animator>();
        }

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

        private void OnBlow(Vector3 position) => _animator.SetBool(IsBlowingKey, true);
    }
}

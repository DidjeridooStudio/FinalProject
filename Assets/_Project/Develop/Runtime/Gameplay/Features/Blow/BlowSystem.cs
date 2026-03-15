using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowSystem : IInitializableSystem, IDisposableSystem
    {
        private ReactiveEvent<Vector3> _blowRequest;
        private ReactiveEvent<Vector3> _blowEvent;

        private IDisposable _blowRequestDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _blowRequest = entity.BlowRequest;
            _blowEvent = entity.BlowEvent;

            _blowRequestDisposable = _blowRequest.Subcribe(OnBlowRequest);
        }

        public void OnDispose()
        {
            _blowRequestDisposable.Dispose();
        }

        #endregion

        private void OnBlowRequest(Vector3 position)
        {
            _blowEvent.Invoke(position);
        }
    }
}

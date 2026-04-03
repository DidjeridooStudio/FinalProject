using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class DeathAfterClearAllEnemiesStage : IInitializableSystem, IDisposableSystem
    {
        private ReactiveVariable<bool> _isDead;
        private ReactiveEvent _endStageEvent;

        private IDisposable _endStageEventDisposable;

        #region Interface

        public void OnInit(Entity entity)
        {
            _isDead = entity.IsDead;
            _endStageEvent = entity.EndClearAllEnemiesStageEvent;

            _endStageEventDisposable = _endStageEvent.Subcribe(OnEndStage);
        }

        public void OnDispose()
        {
            _endStageEventDisposable.Dispose();
        }

        #endregion

        private void OnEndStage()
        {
            _isDead.Value = true;
        }
    }
}

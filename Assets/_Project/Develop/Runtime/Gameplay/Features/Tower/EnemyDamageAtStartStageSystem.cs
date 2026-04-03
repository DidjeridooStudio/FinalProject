using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class EnemyDamageAtStartStageSystem : IInitializableSystem, IDisposableSystem
    {
        private Entity _entity;
        private Dictionary<StatTypes, float> _modifiedStats;
        private EntitiesLifeContext _entitiesLifeContext;

        float _enemyQuantityDealDamage;
        float _startDamage;
        float _enemyQuantityToStartDamage;

        private ReactiveEvent _startClearAllEnemiesStageEvent;

        private IDisposable _startClearAllEnemiesStageEventDisposable;

        public EnemyDamageAtStartStageSystem(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public void OnInit(Entity entity)
        {
            _entity = entity;
            _modifiedStats = entity.ModifiedStats;
            _startClearAllEnemiesStageEvent = entity.StartClearAllEnemiesStageEvent;

            _entitiesLifeContext.Added += OnEntityAdded;
            _startClearAllEnemiesStageEventDisposable = _startClearAllEnemiesStageEvent.Subcribe(OnStartClearAllEnemiesStageEvent);

            _startDamage = _modifiedStats[StatTypes.StartDamage];
            _enemyQuantityToStartDamage = _modifiedStats[StatTypes.EnemyQuantityToStartDamage];
        }

        public void OnDispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
            _startClearAllEnemiesStageEventDisposable.Dispose();
        }

        private void OnEntityAdded(Entity entity)
        {
            if (_enemyQuantityToStartDamage == 0 || _startDamage == 0)
                return;

            if (_enemyQuantityDealDamage >= _enemyQuantityToStartDamage)
                return;

            if (entity.HasComponent<TakeDamageRequest>())
            {
                if (EntitiesHepler.TryTakeDamageFrom(_entity, entity, _startDamage))
                    _enemyQuantityDealDamage++;
            }
        }

        private void OnStartClearAllEnemiesStageEvent()
        {
            _enemyQuantityDealDamage = 0;
        }
    }
}

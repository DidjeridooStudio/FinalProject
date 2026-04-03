using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class TowerHealSystem : IInitializableSystem, IDisposableSystem
    {
        private Dictionary<StatTypes, float> _modifiedStats;

        private ReactiveEvent<Entity> _towerHealRequest;

        private IDisposable _towerHealRequestDisposable;

        public void OnInit(Entity entity)
        {
            _modifiedStats = entity.ModifiedStats;
            _towerHealRequest = entity.TowerHealRequest;

            _towerHealRequestDisposable = _towerHealRequest.Subcribe(OnTowerHealRequest);
        }

        public void OnDispose()
        {
            _towerHealRequestDisposable.Dispose();
        }

        private void OnTowerHealRequest(Entity tower)
        {
            float percentToHeal = _modifiedStats[StatTypes.TowerHeal]/100;

            ReactiveVariable<float> currentHealth = tower.CurrentHealth;
            ReactiveVariable<float> maxHealth = tower.MaxHealth;

            if (percentToHeal <= 0 || currentHealth.Value >= maxHealth.Value)
                return;

            float healthAfterHeal = currentHealth.Value + maxHealth.Value * percentToHeal;

            currentHealth.Value = healthAfterHeal < maxHealth.Value ? healthAfterHeal : maxHealth.Value;

            tower.TowerHealEvent?.Invoke();
        }
    }
}

using Assets._Project.Develop.Runtime.Configs.Meta.Stats;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System.Collections.Generic;
using System.Linq;
using static Assets._Project.Develop.Runtime.Configs.Meta.Stats.PlayerStatsUpgradeConfig;

namespace Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade
{
    public class StatsUpgradeService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private readonly Dictionary<StatTypes, ReactiveVariable<int>> _statsLevels = new Dictionary<StatTypes, ReactiveVariable<int>>();
        private ConfigsProviderService _configsProviderService;

        public StatsUpgradeService(PlayerDataProvider playerDataProvider, ConfigsProviderService configsProviderService)
        {
            _configsProviderService = configsProviderService;

            playerDataProvider.RegisterDataReader(this);
            playerDataProvider.RegisterDataWriters(this);
        }

        public List<StatTypes> AvailableStats => _statsLevels.Keys.ToList();

        public IReadOnlyVariable<int> GetStatLevelFor(StatTypes statType) => _statsLevels[statType];

        private PlayerStatsUpgradeConfig PlayerStatsUpgradeConfig => _configsProviderService.GetConfig<PlayerStatsUpgradeConfig>();

        public float GetCurrentStatValueFor(StatTypes statType) => PlayerStatsUpgradeConfig.GetStatConfig(statType).StatValues[_statsLevels[statType].Value-1];

        public CurrencyTypes GetUpgradeCostTypeFor(StatTypes statType) => PlayerStatsUpgradeConfig.GetStatConfig(statType).CostType;

        public bool TryGetStatValueForNextLevel(StatTypes type, out float statValue)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if (statData.StatValues.Count <= _statsLevels[type].Value)
            {
                statValue = 0;
                return false;
            }

            statValue = statData.StatValues[_statsLevels[type].Value];
            return true;
        }

        public bool TryGetUpgradeCostFor(StatTypes type, out CurrencyTypes costType, out int cost)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if (statData.UpgradeToNextLevelCost.Count <= _statsLevels[type].Value-1)
            {
                costType = default(CurrencyTypes);
                cost = 0;
                return false;
            }

            costType = statData.CostType;
            cost = statData.UpgradeToNextLevelCost[_statsLevels[type].Value - 1];
            return true;
        }

        public bool TryUpgradeStat(StatTypes type)
        {
            StatUpgradeCostConfig statData = PlayerStatsUpgradeConfig.GetStatConfig(type);

            if (statData.StatValues.Count <= _statsLevels[type].Value)
                return false;

            _statsLevels[type].Value += 1;
            return true;
        }

        #region Interface

        public void ReadFrom(PlayerData data)
        {
            foreach (KeyValuePair<StatTypes, int> statLevel in data.StatsUpgradeLevel)
            {
                if (_statsLevels.ContainsKey(statLevel.Key))
                    _statsLevels[statLevel.Key].Value = statLevel.Value;
                else
                    _statsLevels.Add(statLevel.Key, new ReactiveVariable<int>(statLevel.Value));
            }
        }

        public void WriteTo(PlayerData data)
        {
            foreach (var statLevel in _statsLevels)
            {
                if (data.StatsUpgradeLevel.ContainsKey(statLevel.Key))
                    data.StatsUpgradeLevel[statLevel.Key] = statLevel.Value.Value;
                else
                    data.StatsUpgradeLevel.Add(statLevel.Key, statLevel.Value.Value);
            }
        }

        #endregion
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Configs.Meta;
using Assets._Project.Develop.Runtime.Configs.Meta.Stats;
using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Utilies.AssetsManagment;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Utilies.ConfigsManagment
{
    public class ResourcesConfigsLoader : IConfigsLoader
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;
        private readonly Dictionary<Type, string> _configsResourcesPaths = new Dictionary<Type, string>()
    {
        {typeof(LevelConfig), "Configs/LevelConfig" },
        {typeof(StartWalletConfig), "Configs/StartWalletConfig" },
        {typeof(CurrencyIconsConfig), "Configs/CurrencyIconsConfig" },
        {typeof(StandardSettingsConfig), "Configs/StandardSettingsConfig" },
        {typeof(HeroConfig), "Configs/Entities/HeroConfig" },
        {typeof(GameLevelsListConfig), "Configs/Levels/GameLevelsListConfig" },
        {typeof(PlayerEntityConfig), "Configs/Entities/PlayerEntityConfig" },
        {typeof(MineEntityConfig), "Configs/Entities/MineEntityConfig" },
        {typeof(ToxicPuddleConfig), "Configs/Entities/ToxicPuddleConfig" },
        {typeof(TurretEntityConfig), "Configs/Entities/TurretEntityConfig" },
        {typeof(ShooterEntityConfig), "Configs/Entities/ShooterEntityConfig" },
        {typeof(PlayerStatsUpgradeConfig), "Configs/Stats/PlayerStatsUpgradeConfig" },
        {typeof(StatsViewConfig), "Configs/Stats/StatsViewConfig" },
    };

        public ResourcesConfigsLoader(ResourcesAssetsLoader resourcesAssetsLoader)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
        }

        #region Interface

        public IEnumerator LoadAsync(Action<Dictionary<Type, object>> onConfigsLoaded)
        {
            Dictionary<Type, object> loadedConfigs = new Dictionary<Type, object>();

            foreach (KeyValuePair<Type, string> configsResourcesPath in _configsResourcesPaths)
            {
                ScriptableObject config = _resourcesAssetsLoader.Load<ScriptableObject>(configsResourcesPath.Value);
                loadedConfigs.Add(configsResourcesPath.Key, config);
                yield return null;
            }

            onConfigsLoaded?.Invoke(loadedConfigs);
        }

        #endregion
    }
}
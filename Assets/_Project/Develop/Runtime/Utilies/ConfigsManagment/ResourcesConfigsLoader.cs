using Assets._Project.Develop.Runtime.Configs.Meta;
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
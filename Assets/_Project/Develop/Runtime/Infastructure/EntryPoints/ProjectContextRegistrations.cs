using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ProjectContextRegistrations
{
    public static void Process(DIContainer container)
    {
        container.RegisterAsSingle(CreatePlayerDataProvider);
        container.RegisterAsSingle(CreateProgressionService).NonLazy();
        container.RegisterAsSingle(CreateSaveLoadService);
        container.RegisterAsSingle(CreateWalletService).NonLazy();
        container.RegisterAsSingle(CreateScenesLoaderService);
        container.RegisterAsSingle(CreateScenesSwitcherService);
        container.RegisterAsSingle<ILoadingScreen>(CreateStandartLoadingScreen);
        container.RegisterAsSingle(CreateConfigsProviderService);
        container.RegisterAsSingle(CreateResourcesAssetsLoader);
        container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
    }

    private static ProgressionService CreateProgressionService(DIContainer container) => new ProgressionService(container.Resolve<PlayerDataProvider>());

    private static PlayerDataProvider CreatePlayerDataProvider(DIContainer container)
    {
        ISaveLoadService saveLoadService = container.Resolve<SaveLoadService>();
        ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();

        return new PlayerDataProvider(saveLoadService, configsProviderService);
    }

    private static SaveLoadService CreateSaveLoadService(DIContainer container)
    {
        IDataSerializer serializer = new JsonSerializer();
        IDataKeyStorage keyStorage = new MapDataKeyStorage();

        string saveFolderPath = Application.persistentDataPath;

        IDataRepository repository = new LocalFileDataRepository(saveFolderPath, "json");

        return new SaveLoadService(serializer, keyStorage, repository);
    }

    private static WalletService CreateWalletService(DIContainer container)
    {
        Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>();

        foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            currencies.Add(currencyType, new ReactiveVariable<int>());

        ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();

        return new WalletService(currencies, container.Resolve<PlayerDataProvider>(), configsProviderService);
    }

    private static ScenesLoaderService CreateScenesLoaderService(DIContainer container)
    {
        return new ScenesLoaderService();
    }

    private static ScenesSwitcherService CreateScenesSwitcherService(DIContainer container)
    {
        ScenesLoaderService scenesLoaderService = container.Resolve<ScenesLoaderService>();
        ILoadingScreen loadingScreen = container.Resolve<ILoadingScreen>();

        return new ScenesSwitcherService(scenesLoaderService, loadingScreen, container);
    }

    private static StandartLoadingScreen CreateStandartLoadingScreen(DIContainer container)
    {
        ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

        StandartLoadingScreen standartLoadingScreen = resourcesAssetsLoader.Load<StandartLoadingScreen>("Utilities/StandartLoadingScreen");

        return Object.Instantiate(standartLoadingScreen);
    }

    private static ConfigsProviderService CreateConfigsProviderService(DIContainer container)
    {
        ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

        ResourcesConfigsLoader resourcesConfigsLoader = new ResourcesConfigsLoader(resourcesAssetsLoader);

        return new ConfigsProviderService(resourcesConfigsLoader);
    }

    private static ResourcesAssetsLoader CreateResourcesAssetsLoader(DIContainer container)
    {
        return new ResourcesAssetsLoader();
    }

    private static CoroutinesPerformer CreateCoroutinesPerformer(DIContainer container)
    {
        ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

        CoroutinesPerformer coroutinesPerformerPrefab = resourcesAssetsLoader.Load<CoroutinesPerformer>("Utilities/CoroutinesPerformer");

        return Object.Instantiate(coroutinesPerformerPrefab);
    }
}

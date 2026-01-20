using UnityEngine;

public class ProjectContextRegistrations
{
    public static void Process(DIContainer container)
    {
        container.RegisterAsSingle(CreateScenesLoaderService);
        container.RegisterAsSingle(CreateScenesSwitcherService);
        container.RegisterAsSingle<ILoadingScreen>(CreateStandartLoadingScreen);
        container.RegisterAsSingle(CreateConfigsProviderService);
        container.RegisterAsSingle(CreateResourcesAssetsLoader);
        container.RegisterAsSingle<ICoroutinesPerformer>(CreateCoroutinesPerformer);
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

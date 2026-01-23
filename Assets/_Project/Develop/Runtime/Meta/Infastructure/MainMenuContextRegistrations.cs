
public class MainMenuContextRegistrations
{
    public static void Process(DIContainer container)
    {
        container.RegisterAsSingle(CreateModeSelectionService);
    }

    private static ModeSelectionService CreateModeSelectionService(DIContainer container)
    {
        ScenesSwitcherService scenesSwitcherService = container.Resolve<ScenesSwitcherService>();
        ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
        ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

        return new ModeSelectionService(configsProviderService, scenesSwitcherService, coroutinesPerformer);
    }
}

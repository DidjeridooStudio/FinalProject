
public class MainMenuContextRegistrations
{
    public static void Process(DIContainer container)
    {
        container.RegisterAsSingle(CreateModeSelectionService);
        container.RegisterAsSingle(CreateProgressManagementService);
    }
    private static ProgressManagementService CreateProgressManagementService(DIContainer container)
    {
        ProgressionService progressionService = container.Resolve<ProgressionService>();
        WalletService walletService = container.Resolve<WalletService>();
        ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();

        return new ProgressManagementService(walletService, progressionService, configsProviderService);
    }

    private static ModeSelectionService CreateModeSelectionService(DIContainer container)
    {
        ScenesSwitcherService scenesSwitcherService = container.Resolve<ScenesSwitcherService>();
        ConfigsProviderService configsProviderService = container.Resolve<ConfigsProviderService>();
        ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();

        return new ModeSelectionService(configsProviderService, scenesSwitcherService, coroutinesPerformer);
    }
}

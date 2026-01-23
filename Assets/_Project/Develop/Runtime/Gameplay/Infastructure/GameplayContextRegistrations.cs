
public class GameplayContextRegistrations
{
    public static void Process(DIContainer container, GameplayInputArgs args)
    {
        container.RegisterAsSingle(container => CreateGameplayCircle(container, args));
        container.RegisterAsSingle(CreateReadUserInputService);
        container.RegisterAsSingle(container => CreateGenerateRandomStringService(container, args));
    }

    private static ReadUserInputService CreateReadUserInputService(DIContainer container) => new ReadUserInputService();
    private static GenerateRandomStringService CreateGenerateRandomStringService(DIContainer container, GameplayInputArgs args)
        => new GenerateRandomStringService(args.SymbolSet, args.SymbolsQuanity);

    private static GameplayCircle CreateGameplayCircle(DIContainer container, GameplayInputArgs args)
    {
        ScenesSwitcherService scenesSwitcherService = container.Resolve<ScenesSwitcherService>();
        ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
        GenerateRandomStringService generateRandomStringService = container.Resolve<GenerateRandomStringService>();
        ReadUserInputService readUserInputService = container.Resolve<ReadUserInputService>();
        ProgressionService progressionService = container.Resolve<ProgressionService>();
        WalletService walletService = container.Resolve<WalletService>();
        PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

        return new GameplayCircle(scenesSwitcherService, coroutinesPerformer, generateRandomStringService,
            readUserInputService, progressionService, walletService, args, playerDataProvider);
    }
}

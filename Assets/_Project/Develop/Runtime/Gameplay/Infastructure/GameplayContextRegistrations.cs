
public class GameplayContextRegistrations
{
    public static void Process(DIContainer container, GameplayInputArgs args)
    {
        container.RegisterAsSingle(CreateGameplayCircle);
        container.RegisterAsSingle(CreateReadUserInputService);
        container.RegisterAsSingle(CreateGenerateRandomStringService);
    }

    private static ReadUserInputService CreateReadUserInputService(DIContainer container) => new ReadUserInputService();
    private static GenerateRandomStringService CreateGenerateRandomStringService(DIContainer container) => new GenerateRandomStringService();

    private static GameplayCircle CreateGameplayCircle(DIContainer container)
    {
        ScenesSwitcherService scenesSwitcherService = container.Resolve<ScenesSwitcherService>();
        ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
        GenerateRandomStringService generateRandomStringService = container.Resolve<GenerateRandomStringService>();
        ReadUserInputService readUserInputService = container.Resolve<ReadUserInputService>();

        return new GameplayCircle(scenesSwitcherService, coroutinesPerformer, generateRandomStringService, readUserInputService);
    }
}

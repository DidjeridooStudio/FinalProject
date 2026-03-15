using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Gameplay.States;
using Assets._Project.Develop.Runtime.Gameplay.Utilities;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.GamePlay;
using Assets._Project.Develop.Runtime.Utilies.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infastructure
{
    public class GameplayContextRegistrations
    {
        private static GameplayInputArgs _gameplayInputArgs;

        public static void Process(DIContainer container, GameplayInputArgs args)
        {
            _gameplayInputArgs = args;

            container.RegisterAsSingle(CreateGameplayPopupService);
            container.RegisterAsSingle(CreateGameplayScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateGameplayPresentersFactory);
            container.RegisterAsSingle(CreateGameplayUIRoot).NonLazy();

            container.RegisterAsSingle(CreateRaycastOnMousePositionService);
            container.RegisterAsSingle(CreateTowerFactory);
            container.RegisterAsSingle(CreateTowerHolderService).NonLazy();
            container.RegisterAsSingle(CreateGameplayStatesContext);
            container.RegisterAsSingle(CreateGameplayStatesFactory);
            container.RegisterAsSingle(CreateMainHeroHolderService).NonLazy();
            container.RegisterAsSingle(CreatePreperationTriggerService);
            container.RegisterAsSingle(CreateStageProviderService);
            container.RegisterAsSingle(CreateStagesFactory);
            container.RegisterAsSingle(CreateEnemiesFactory);
            container.RegisterAsSingle(CreateMainHeroFactory);
            container.RegisterAsSingle<IInputService>(CreateDesktopInput);
            container.RegisterAsSingle(CreateAIBrainsContext);
            container.RegisterAsSingle(CreateBrainsFactory);
            container.RegisterAsSingle(CreateCollidersRegistryService);
            container.RegisterAsSingle(CreateMonoEntitiesFactory).NonLazy();
            container.RegisterAsSingle(CreateEntitiesLifeContext);
            container.RegisterAsSingle(CreateEntitiesFactory);


            //container.RegisterAsSingle(container => CreateGameplayCircleL3(container, args));
            //container.RegisterAsSingle(container => CreateGameplayCircle(container, args));
            //container.RegisterAsSingle(CreateReadUserInputService);
            //container.RegisterAsSingle(container => CreateGenerateRandomStringService(container, args));
        }

        private static RaycastOnMousePositionService CreateRaycastOnMousePositionService(DIContainer container) => new RaycastOnMousePositionService(container.Resolve<IInputService>());

        private static PlayersEntitiesFactory CreateTowerFactory(DIContainer container) => new PlayersEntitiesFactory(container, container.Resolve<BrainsFactory>());

        private static ToweHolderService CreateTowerHolderService(DIContainer container) => new ToweHolderService(container.Resolve<EntitiesLifeContext>());

        private static GameplayStatesContext CreateGameplayStatesContext(DIContainer container)
        {
            return new GameplayStatesContext(container.Resolve<GameplayStatesFactory>().CreateGameplayStateMachine(_gameplayInputArgs));
        }

        private static GameplayStatesFactory CreateGameplayStatesFactory(DIContainer container) => new GameplayStatesFactory(container);

        private static MainHeroHolderService CreateMainHeroHolderService(DIContainer container) => new MainHeroHolderService(container.Resolve<EntitiesLifeContext>());

        private static PreparationTriggerService CreatePreperationTriggerService(DIContainer container)
        {
            return new PreparationTriggerService(
                container.Resolve<EntitiesFactory>(),
                container.Resolve<EntitiesLifeContext>());
        }

        private static StageProviderService CreateStageProviderService(DIContainer container)
        {
            return new StageProviderService(
                _gameplayInputArgs.LevelConfig,
                container.Resolve<StagesFactory>());
        }

        private static StagesFactory CreateStagesFactory(DIContainer container) => new StagesFactory(container);

        private static EnemiesFactory CreateEnemiesFactory(DIContainer container) => new EnemiesFactory(container);

        private static MainHeroFactory CreateMainHeroFactory(DIContainer container) => new MainHeroFactory(container);

        private static DesktopInput CreateDesktopInput(DIContainer container) => new DesktopInput();

        private static AIBrainsContext CreateAIBrainsContext(DIContainer container) => new AIBrainsContext();

        private static BrainsFactory CreateBrainsFactory(DIContainer container) => new BrainsFactory(container);

        private static CollidersRegistryService CreateCollidersRegistryService(DIContainer container) => new CollidersRegistryService();

        private static MonoEntitiesFactory CreateMonoEntitiesFactory(DIContainer container)
        {
            return new MonoEntitiesFactory(
                container.Resolve<ResourcesAssetsLoader>(),
                container.Resolve<EntitiesLifeContext>(),
                container.Resolve<CollidersRegistryService>());
        }

        private static EntitiesLifeContext CreateEntitiesLifeContext(DIContainer container) => new EntitiesLifeContext();

        private static EntitiesFactory CreateEntitiesFactory(DIContainer container) => new EntitiesFactory(container);

        private static GameplayPopupService CreateGameplayPopupService(DIContainer container)
        {
            return new GameplayPopupService(
                container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<GameplayUIRoot>(),
                container.Resolve<GameplayPresentersFactory>());
        }

        private static GameplayScreenPresenter CreateGameplayScreenPresenter(DIContainer container)
        {
            GameplayUIRoot gameplayUIRoot = container.Resolve<GameplayUIRoot>();

            GameplayScreenView screenView = container.Resolve<ViewsFactory>().Create<GameplayScreenView>(ViewsIDs.GameplayScreenView, gameplayUIRoot.HUDLayer);

            return container.Resolve<GameplayPresentersFactory>().CreateGameplayScreenPresenter(screenView);
        }

        private static GameplayPresentersFactory CreateGameplayPresentersFactory(DIContainer container) => new GameplayPresentersFactory(container);

        private static GameplayUIRoot CreateGameplayUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            GameplayUIRoot gameplayUIRoot = resourcesAssetsLoader.Load<GameplayUIRoot>("UI/GameplayUIRoot");

            return Object.Instantiate(gameplayUIRoot);
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

        private static GameplayCircleL3 CreateGameplayCircleL3(DIContainer container, GameplayInputArgs args)
        {
            ICoroutinesPerformer coroutinesPerformer = container.Resolve<ICoroutinesPerformer>();
            GenerateRandomStringService generateRandomStringService = container.Resolve<GenerateRandomStringService>();
            ProgressionService progressionService = container.Resolve<ProgressionService>();
            WalletService walletService = container.Resolve<WalletService>();
            PlayerDataProvider playerDataProvider = container.Resolve<PlayerDataProvider>();

            return new GameplayCircleL3(coroutinesPerformer, generateRandomStringService,
                progressionService, walletService, args, playerDataProvider);
        }
    }
}
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Meta.Utilities;
using Assets._Project.Develop.Runtime.UI;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.UI.MainMenu;
using Assets._Project.Develop.Runtime.UI.Wallet;
using Assets._Project.Develop.Runtime.Utilies.AssetsManagment;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Meta.Infastructure
{
    public class MainMenuContextRegistrations
    {
        public static void Process(DIContainer container)
        {
            container.RegisterAsSingle(CreateMainMenuPopupService);
            container.RegisterAsSingle(CreateMainMenuScreenPresenter).NonLazy();
            container.RegisterAsSingle(CreateMainMenuPresentersFactory);
            container.RegisterAsSingle(CreateMainMenuUIRoot).NonLazy();
            container.RegisterAsSingle(CreateModeSelectionService);
            container.RegisterAsSingle(CreateProgressManagementService);
        }

        private static MainMenuPopupService CreateMainMenuPopupService(DIContainer container)
        {
            return new MainMenuPopupService(
                container.Resolve<ViewsFactory>(),
                container.Resolve<ProjectPresentersFactory>(),
                container.Resolve<MainMenuUIRoot>(),
                container.Resolve<MainMenuPresentersFactory>());
        }

        private static MainMenuScreenPresenter CreateMainMenuScreenPresenter(DIContainer container)
        {
            MainMenuUIRoot mainMenuUIRoot = container.Resolve<MainMenuUIRoot>();

            MainMenuScreenView screenView = container.Resolve<ViewsFactory>().Create<MainMenuScreenView>(ViewsIDs.MainMenuScreenView, mainMenuUIRoot.HUDLayer);

            return container.Resolve<MainMenuPresentersFactory>().CreateMainMenuScreenPresenter(screenView);
        }

        private static MainMenuPresentersFactory CreateMainMenuPresentersFactory(DIContainer container) => new MainMenuPresentersFactory(container);

        private static MainMenuUIRoot CreateMainMenuUIRoot(DIContainer container)
        {
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            MainMenuUIRoot mainMenuUIRoot = resourcesAssetsLoader.Load<MainMenuUIRoot>("UI/mainMenuUIRoot");

            return Object.Instantiate(mainMenuUIRoot);
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
}
using Assets._Project.Develop.Runtime.Gameplay.Features;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.MainHero;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class GameplayStatesFactory
    {
        private readonly DIContainer _container;

        public GameplayStatesFactory(DIContainer container)
        {
            _container = container;
        }

        public GameplayStateMachine CreateGameplayStateMachine(GameplayInputArgs inputArgs)
        {
            IInputService inputService = _container.Resolve<IInputService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            ToweHolderService towerHolderService = _container.Resolve<ToweHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopState();
            WinState winState = CreateWinState(inputArgs);
            DefeatState defeatState = CreateDefeatState();

            ICompositeCondition coreLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => Input.GetKeyDown(KeyCode.S)))
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            FuncCondition coreLoopToDefeatStateCondition = new FuncCondition(() =>
            {
                if (towerHolderService.Tower != null)
                    return towerHolderService.Tower.IsDead.Value;

                return false;
            });

            GameplayStateMachine GameplayCycle = new GameplayStateMachine();

            GameplayCycle.AddState(coreLoopState);
            GameplayCycle.AddState(winState);
            GameplayCycle.AddState(defeatState);

            GameplayCycle.AddTransition(coreLoopState, winState, coreLoopToWinStateCondition);
            GameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeatStateCondition);

            return GameplayCycle;
        }

        public GameplayStateMachine CreateGameplayStateMachineUA(GameplayInputArgs inputArgs)
        {
            PreparationTriggerService preparationTriggerService = _container.Resolve<PreparationTriggerService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();
            MainHeroHolderService mainHeroHolderService = _container.Resolve<MainHeroHolderService>();

            GameplayStateMachine coreLoopState = CreateCoreLoopStateUA();
            WinStateUA winState = CreateWinStateUA(inputArgs);
            DefeatState defeatState = CreateDefeatState();

            ICompositeCondition coreLoopToWinStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => preparationTriggerService.HasMainHeroContact.Value))
                .Add(new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage() == false));

            FuncCondition coreLoopToDefeatStateCondition = new FuncCondition(() =>
            {
                if (mainHeroHolderService.MainHero != null)
                    return mainHeroHolderService.MainHero.IsDead.Value;

                return false;
            });

            GameplayStateMachine GameplayCycle = new GameplayStateMachine();

            GameplayCycle.AddState(coreLoopState);
            GameplayCycle.AddState(winState);
            GameplayCycle.AddState(defeatState);

            GameplayCycle.AddTransition(coreLoopState, winState, coreLoopToWinStateCondition);
            GameplayCycle.AddTransition(coreLoopState, defeatState, coreLoopToDefeatStateCondition);

            return GameplayCycle;
        }

        public GameplayStateMachine CreateCoreLoopState()
        {
            IInputService inputService = _container.Resolve<IInputService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            PreparationState preparationState = CreatePreparationState();
            StageProcessState stageProcessState = CreateStageProcessState();

            ICompositeCondition preparationToStageProcessCondition = new CompositeCondition()
                .Add(new FuncCondition(() => inputService.StartButtonClicked))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition stageProcessToPreparationCondition = new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(preparationState, stageProcessState, preparationToStageProcessCondition);
            coreLoopState.AddTransition(stageProcessState, preparationState, stageProcessToPreparationCondition);

            return coreLoopState;
        }

        public GameplayStateMachine CreateCoreLoopStateUA()
        {
            PreparationTriggerService preparationTriggerService = _container.Resolve<PreparationTriggerService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            PreparationStateUA preparationState = CreatePreparationStateUA();
            StageProcessState stageProcessState = CreateStageProcessState();

            ICompositeCondition preparationToStageProcessCondition = new CompositeCondition()
                .Add(new FuncCondition(() => preparationTriggerService.HasMainHeroContact.Value))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            FuncCondition stageProcessToPreparationCondition = new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            GameplayStateMachine coreLoopState = new GameplayStateMachine();

            coreLoopState.AddState(preparationState);
            coreLoopState.AddState(stageProcessState);

            coreLoopState.AddTransition(preparationState, stageProcessState, preparationToStageProcessCondition);
            coreLoopState.AddTransition(stageProcessState, preparationState, stageProcessToPreparationCondition);

            return coreLoopState;
        }

        public PreparationState CreatePreparationState() => new PreparationState(_container.Resolve<PreparationTriggerService>());

        public PreparationStateUA CreatePreparationStateUA() => new PreparationStateUA(_container.Resolve<PreparationTriggerService>());

        public StageProcessState CreateStageProcessState() => new StageProcessState(_container.Resolve<StageProviderService>());
        
        public WinStateUA CreateWinStateUA(GameplayInputArgs inputArgs)
        {
            return new WinStateUA(
                _container.Resolve<IInputService>(),
                _container.Resolve<LevelsProgressionService>(),
                inputArgs,
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ScenesSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>());
        }

        public WinState CreateWinState(GameplayInputArgs inputArgs)
        {
            return new WinState(
                _container.Resolve<IInputService>(),
                _container.Resolve<PlayerDataProvider>(),
                _container.Resolve<ScenesSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ProgressionService>(),
                inputArgs);
        }

        public DefeatState CreateDefeatState()
        {
            return new DefeatState(
                _container.Resolve<IInputService>(),
                _container.Resolve<ScenesSwitcherService>(),
                _container.Resolve<ICoroutinesPerformer>(),
                _container.Resolve<ProgressionService>(),
                _container.Resolve<PlayerDataProvider>());
        }
    }
}

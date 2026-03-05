using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using Assets._Project.Develop.Runtime.Utilies.Timer;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;
        private readonly TimerServiceFactory _timerServiceFactory;
        private readonly AIBrainsContext _brainsContext;
        private readonly IInputService _inputService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public BrainsFactory(DIContainer container)
        {
            _container = container;
            _timerServiceFactory = _container.Resolve<TimerServiceFactory>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _inputService = _container.Resolve<IInputService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public StateMachineBrain CreatePlayerEntityBrain(Entity entity)
        {
            PlayerPreparationState playerPreparationState = new PlayerPreparationState(entity, _inputService);
            PlayerBlowOnMouseClickState playerBlowOnMouseClickState = new PlayerBlowOnMouseClickState(entity, _inputService, _container.Resolve<RaycastOnMousePositionService>());

            IInputService inputService = _container.Resolve<IInputService>();
            StageProviderService stageProviderService = _container.Resolve<StageProviderService>();

            ICompositeCondition preparationToAttackCondition = new CompositeCondition()
                .Add(new FuncCondition(() => inputService.StartButtonClicked))
                .Add(new FuncCondition(() => stageProviderService.HasNextStage()));

            ICondition attackToPreparationCondition = new FuncCondition(() => stageProviderService.CurrentStageResult.Value == StageResults.Completed);

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(playerPreparationState);
            behaviour.AddState(playerBlowOnMouseClickState);

            behaviour.AddTransition(playerPreparationState, playerBlowOnMouseClickState, preparationToAttackCondition);
            behaviour.AddTransition(playerBlowOnMouseClickState, playerPreparationState, attackToPreparationCondition);

            StateMachineBrain brain = new StateMachineBrain(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateBlowEntityBrain(Entity entity)
        {
            ToweHolderService towerHolderService = _container.Resolve<ToweHolderService>();

            MoveToTargetState moveToTargetState = new MoveToTargetState(entity, towerHolderService.Tower.Transform);

            BlowState blowState = new BlowState(entity);

            ICondition moveToBlowState = new FuncCondition(() => (towerHolderService.Tower.Transform.position - entity.Transform.position).magnitude <= 2f);

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(moveToTargetState);
            behaviour.AddState(blowState);

            behaviour.AddTransition(moveToTargetState, blowState, moveToBlowState);

            StateMachineBrain brain = new StateMachineBrain(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateLessHealthTargetTeleportingEntityBrain(Entity entity, ITargetSelector targetSelector)
        {
            LessHealthTargetTeleportState lessHealthTargetTeleportState = new LessHealthTargetTeleportState(entity, 40, 2);

            EnergyRefillState energyRefillState = new EnergyRefillState();

            ReactiveVariable<float> currentEnergy = entity.CurrentEnergy;
            ReactiveVariable<float> maxEnergy = entity.MaxEnergy;

            ICondition fromTeleportToEnergyRefillStateCondition = new FuncCondition(() => currentEnergy.Value <= maxEnergy.Value * 40 / 100);

            ICondition fromEnergyRefillToTeleportStateCondition = new FuncCondition(() => currentEnergy.Value >= maxEnergy.Value * 40 / 100);

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(lessHealthTargetTeleportState);
            behaviour.AddState(energyRefillState);

            behaviour.AddTransition(lessHealthTargetTeleportState, energyRefillState, fromTeleportToEnergyRefillStateCondition);
            behaviour.AddTransition(energyRefillState, lessHealthTargetTeleportState, fromEnergyRefillToTeleportStateCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateRandomTeleportingEntityBrain(Entity entity)
        {
            StateMachineBrain brain = new StateMachineBrain(CreateRandomTeleportStateMachine(entity));
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateGhostBrain(Entity entity)
        {
            StateMachineBrain brain = new StateMachineBrain(CreateRandomMovementStateMachine(entity));
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroBrain(Entity entity, ITargetSelector targetSelector)
        {
            AIStateMachine combatState = CreateAutoAttackStateMachine(entity);

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromMovementToCombatStateCondition = new CompositeCondition()
                .Add(new FuncCondition(() => currentTarget.Value != null))
                .Add(new FuncCondition(() => _inputService.Direction == Vector3.zero));

            ICompositeCondition fromCombatToMovementStateCondition = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => currentTarget.Value == null))
                .Add(new FuncCondition(() => _inputService.Direction != Vector3.zero));

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behaviour.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            FindTargetState findTargetState = new FindTargetState(targetSelector, _entitiesLifeContext, entity);

            AIParallelState parallelState = new AIParallelState(findTargetState, behaviour);

            AIStateMachine rootStateMachine = new AIStateMachine();
            rootStateMachine.AddState(parallelState);

            StateMachineBrain brain = new StateMachineBrain(rootStateMachine);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        public StateMachineBrain CreateMainHeroBrainL_6(Entity entity)
        {
            AIStateMachine combatState = CreateTargetedAttackStateMachine(entity);

            PlayerInputMovementState movementState = new PlayerInputMovementState(entity, _inputService);

            ICondition fromMovementToCombatStateCondition = new FuncCondition(() => _inputService.Direction == Vector3.zero);

            ICondition fromCombatToMovementStateCondition = new FuncCondition(() => _inputService.Direction != Vector3.zero);

            AIStateMachine behaviour = new AIStateMachine();

            behaviour.AddState(movementState);
            behaviour.AddState(combatState);

            behaviour.AddTransition(movementState, combatState, fromMovementToCombatStateCondition);
            behaviour.AddTransition(combatState, movementState, fromCombatToMovementStateCondition);

            StateMachineBrain brain = new StateMachineBrain(behaviour);
            _brainsContext.SetFor(entity, brain);

            return brain;
        }

        private AIStateMachine CreateRandomTeleportStateMachine(Entity entity)
        {
            RandomTeleportState randomTeleportState = new RandomTeleportState(entity, 2f, 20);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(randomTeleportState);

            return stateMachine;
        }

        private AIStateMachine CreateRandomMovementStateMachine(Entity entity)
        {
            List<IDisposable> disposables = new List<IDisposable>();

            RandomMovementState randomMovementState = new RandomMovementState(entity, 0.5f);
            EmptyState emptyState = new EmptyState();

            TimerService movementTimer = _timerServiceFactory.Create(2f);
            disposables.Add(movementTimer);
            disposables.Add(randomMovementState.Entered.Subcribe(movementTimer.Restart));

            FuncCondition movementTimerEndedCondition = new FuncCondition(() => movementTimer.IsOver);

            TimerService idleTimer = _timerServiceFactory.Create(3f);
            disposables.Add(idleTimer);
            disposables.Add(emptyState.Entered.Subcribe(idleTimer.Restart));

            FuncCondition idleTimerEndedCondition = new FuncCondition(() => idleTimer.IsOver);

            AIStateMachine stateMachine = new AIStateMachine(disposables);

            stateMachine.AddState(randomMovementState);
            stateMachine.AddState(emptyState);

            stateMachine.AddTransition(randomMovementState, emptyState, movementTimerEndedCondition);
            stateMachine.AddTransition(emptyState, randomMovementState, idleTimerEndedCondition);

            return stateMachine;
        }

        private AIStateMachine CreateAutoAttackStateMachine(Entity entity)
        {
            RotateToTargetState rotateToTargetState = new RotateToTargetState(entity);
            AttackTriggerState attackTriggerState = new AttackTriggerState(entity);

            ICondition canAttack = entity.CanStartAttack;
            Transform transform = entity.Transform;
            ReactiveVariable<Entity> currentTarget = entity.CurrentTarget;

            ICompositeCondition fromRotateToAttackCondition = new CompositeCondition()
                .Add(canAttack)
                .Add(new FuncCondition(() =>
                {
                    Entity target = currentTarget.Value;

                    if (target == null)
                        return false;

                    float angelToTarget = Quaternion.Angle(transform.rotation, Quaternion.LookRotation(target.Transform.position - transform.position));
                    return angelToTarget < 3f;
                }));

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(rotateToTargetState);
            stateMachine.AddState(attackTriggerState);

            stateMachine.AddTransition(rotateToTargetState, attackTriggerState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackTriggerState, rotateToTargetState, fromAttackToRotateStateCondition);

            return stateMachine;
        }

        private AIStateMachine CreateTargetedAttackStateMachine(Entity entity)
        {
            PlayerInputRotationState playerInputRotationState = new PlayerInputRotationState(entity, _inputService);
            AttackOnMouseAttackState attackOnMouseAttackState = new AttackOnMouseAttackState(entity, _inputService);

            ReactiveVariable<bool> inAttackProcess = entity.InAttackProcess;

            ICondition fromRotateToAttackCondition = entity.CanStartAttack;
            ICondition fromAttackToRotateStateCondition = new FuncCondition(() => inAttackProcess.Value == false);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(playerInputRotationState);
            stateMachine.AddState(attackOnMouseAttackState);

            stateMachine.AddTransition(playerInputRotationState, attackOnMouseAttackState, fromRotateToAttackCondition);
            stateMachine.AddTransition(attackOnMouseAttackState, playerInputRotationState, fromAttackToRotateStateCondition);

            return stateMachine;
        }
    }
}

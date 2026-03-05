using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack;
using Assets._Project.Develop.Runtime.Gameplay.Features.Attack.Shoot;
using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
using Assets._Project.Develop.Runtime.Gameplay.Features.ContactTakeDamage;
using Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.LifeCycle;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.Sensors;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.Utilies;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly MonoEntitiesFactory _monoEntitiesFactory;
        private readonly CollidersRegistryService _collidersRegistryService;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _monoEntitiesFactory = _container.Resolve<MonoEntitiesFactory>();
            _collidersRegistryService = _container.Resolve<CollidersRegistryService>();
        }

        public Entity CreateMineEntity(Vector3 position, MineEntityConfig mineEntityConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, mineEntityConfig.PrefabPath);

            entity
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(mineEntityConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddBlowRequest()
                .AddBlowEvent()
                .AddBlowRadius(new ReactiveVariable<float>(mineEntityConfig.BlowRadius))
                .AddBlowDamage(new ReactiveVariable<float>(mineEntityConfig.BlowDamage))
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddBlowContactsDetectingEvent();

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity.AddSystem(new MineDetectingSystem());
            entity.AddSystem(new BlowContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new BlowSystem());
            entity.AddSystem(new BlowDamageSystem());
            entity.AddSystem(new DeathAfterBlowDetectorSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new DeathProcessTimerSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreatePlayerEntity(Vector3 position, PlayerEntityConfig config)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, config.PrefabPath);

            entity
                .AddMineSpawnRequest()
                .AddBlowRequest()
                .AddBlowEvent()
                .AddBlowRadius(new ReactiveVariable<float>(config.BlowRadius))
                .AddBlowDamage(new ReactiveVariable<float>(config.BlowDamage))
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddBlowContactsDetectingEvent();

            entity.AddSystem(new MineSpawnOnMoneySystem(
                _container.Resolve<PlayersEntitiesFactory>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<MineEntityConfig>(),
                _container.Resolve<WalletService>(),
                _container.Resolve<ConfigsProviderService>().GetConfig<PlayerEntityConfig>(),
                _container.Resolve<RaycastOnMousePositionService>()));
            entity.AddSystem(new BlowContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new BlowSystem());
            entity.AddSystem(new BlowDamageOnEventSystem());;

            return entity;
        }

        public Entity CreateTowerEntity(GameLevelConfig config)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, config.TowerPosition, config.TowerPrefabPath);

            entity
                .AddMaxHealth(new ReactiveVariable<float>(config.TowerHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(config.TowerHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(2))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent();

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity.AddSystem(new ApplyDamageSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new DeathProcessTimerSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateBlowEntity(Vector3 position, BlowEntityConfig blowEntityConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, blowEntityConfig.PrefabPath);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(blowEntityConfig.MoveSpeed))
                .AddIsMoving()
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(blowEntityConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(blowEntityConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(blowEntityConfig.MaxHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(blowEntityConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddBlowRequest()
                .AddBlowEvent()
                .AddBlowRadius(new ReactiveVariable<float>(blowEntityConfig.BlowRadius))
                .AddBlowDamage(new ReactiveVariable<float>(blowEntityConfig.BlowDamage))
                .AddContactsDetectingMask(Layers.TowerMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddBlowContactsDetectingEvent();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new RigidbodyRotationSystem());
            entity.AddSystem(new BlowContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new BlowSystem());
            entity.AddSystem(new BlowDamageSystem());
            entity.AddSystem(new ApplyDamageSystem());
            entity.AddSystem(new DeathAfterBlowDetectorSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new DeathProcessTimerSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateContactTriggerEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/ContactTriggerEntity");

            entity
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64));

            entity.AddSystem(new BodyContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateTeleportingEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/TeleportingEntity");

            entity
                .AddMaxHealth(new ReactiveVariable<float>(100))
                .AddCurrentHealth(new ReactiveVariable<float>(100))
                .AddIsDead()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddMaxEnergy(new ReactiveVariable<float>(100))
                .AddCurrentEnergy(new ReactiveVariable<float>(100))
                .AddEnergyRefillProcessInitialTime(new ReactiveVariable<float>(2))
                .AddEnergyRefillProcessCurrentTime()
                .AddInEnergyRefillProcess()
                .AddTeleportCastRequest()
                .AddTeleportCastEvent()
                .AddTeleportationRadius(new ReactiveVariable<float>(4))
                .AddTeleportationDamage(new ReactiveVariable<float>(50))
                .AddTeleportationDamageRadius(new ReactiveVariable<float>(5))
                .AddContactsDetectingMask(1 << LayerMask.NameToLayer("Characters"))
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddTeleportContactsDetectingEvent();

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity.AddSystem(new TeleportCastSystem());
            entity.AddSystem(new EnergyRefillSystem());
            entity.AddSystem(new TeleportContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new TeleportDamageSystem());
            entity.AddSystem(new ApplyDamageSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateHeroEntity(Vector3 position, HeroConfig heroConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, heroConfig.PrefabPath);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(heroConfig.MoveSpeed))
                .AddIsMoving()
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(heroConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(heroConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(heroConfig.MaxHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(heroConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddAttackProcessInitialTime(new ReactiveVariable<float>(heroConfig.AttackProcessTime))
                .AddAttackProcessCurrentTime()
                .AddInAttackProcess()
                .AddStartAttackRequest()
                .AddStartAttackEvent()
                .AddEndAttackEvent()
                .AddAttackDelayTime(new ReactiveVariable<float>(heroConfig.AttackDelayTime))
                .AddAttackDelayEndEvent()
                .AddInstantAttackDamage(new ReactiveVariable<float>(heroConfig.InstantAttackDamage))
                .AddAttackCanceledEvent()
                .AddInAttackCooldown()
                .AddAttackCooldownInitialTime(new ReactiveVariable<float>(heroConfig.AttackCooldown))
                .AddAttackCooldownCurrentTime();

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canStartAttack = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false))
                .Add(new FuncCondition(() => entity.InAttackProcess.Value == false))
                .Add(new FuncCondition(() => entity.IsMoving.Value == false))
                .Add(new FuncCondition(() => entity.InAttackCooldown.Value == false));

            ICompositeCondition mustCancelAttack = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.IsMoving.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage)
                .AddCanStartAttack(canStartAttack)
                .AddMustCancelAttack(mustCancelAttack);

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new RigidbodyRotationSystem());
            entity.AddSystem(new AttackCanceledSystem());
            entity.AddSystem(new StartAttackSystem());
            entity.AddSystem(new AttackProcessTimerSystem());
            entity.AddSystem(new AttackDelayEndTriggerSystem());
            entity.AddSystem(new InstantShootSystem(this));
            entity.AddSystem(new EndAttackSystem());
            entity.AddSystem(new AttackCooldownTimerSystem());
            entity.AddSystem(new ApplyDamageSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new DeathProcessTimerSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateProjectileEntity(Vector3 position, Vector3 direction, float damage, Entity owner)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/ProjectileEntity");

            entity
                .AddMoveDirection(new ReactiveVariable<Vector3>(direction))
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddIsMoving()
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(9999))
                .AddIsDead()
                .AddContactsDetectingMask(Layers.CharactersMask | Layers.EnviromentMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(damage))
                .AddDeathMask(Layers.EnviromentMask)
                .AddIsTouchDeathMask()
                .AddIsTouchAnotherTeam()
                .AddTeam(new ReactiveVariable<Teams>(owner.Team.Value));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition(LogicOperations.Or)
                .Add(new FuncCondition(() => entity.IsTouchDeathMask.Value))
                .Add(new FuncCondition(() => entity.IsTouchAnotherTeam.Value));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease);

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new RigidbodyRotationSystem());
            entity.AddSystem(new BodyContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new DealDamageOnContactSystem());
            entity.AddSystem(new DeathMaskTouchDetectorSystem());
            entity.AddSystem(new AnotherTeamTouchDetectorSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateGhostEntity(Vector3 position, GhostConfig ghostConfig)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, ghostConfig.PrefabPath);

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(ghostConfig.MoveSpeed))
                .AddIsMoving()
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(ghostConfig.RotationSpeed))
                .AddMaxHealth(new ReactiveVariable<float>(ghostConfig.MaxHealth))
                .AddCurrentHealth(new ReactiveVariable<float>(ghostConfig.MaxHealth))
                .AddIsDead()
                .AddInDeadProcess()
                .AddDeathProcessInitialTime(new ReactiveVariable<float>(ghostConfig.DeathProcessTime))
                .AddDeathProcessCurrentTime()
                .AddTakeDamageRequest()
                .AddTakeDamageEvent()
                .AddContactsDetectingMask(Layers.CharactersMask)
                .AddContactsColliderBuffer(new Buffer<Collider>(64))
                .AddContactsEntitiesBuffer(new Buffer<Entity>(64))
                .AddBodyContactDamage(new ReactiveVariable<float>(ghostConfig.BodyContactDamage));

            ICompositeCondition canMove = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition canRotate = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            ICompositeCondition mustDie = new CompositeCondition()
                .Add(new FuncCondition(() => entity.CurrentHealth.Value <= 0));

            ICompositeCondition mustSelfRelease = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value))
                .Add(new FuncCondition(() => entity.InDeadProcess.Value == false));

            ICompositeCondition canApplyDamage = new CompositeCondition()
                .Add(new FuncCondition(() => entity.IsDead.Value == false));

            entity
                .AddCanMove(canMove)
                .AddCanRotate(canRotate)
                .AddMustDie(mustDie)
                .AddMustSelfRelease(mustSelfRelease)
                .AddCanApplyDamage(canApplyDamage);

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new RigidbodyRotationSystem());
            entity.AddSystem(new BodyContactsDetectingSystem());
            entity.AddSystem(new BodyContactsEntitiesFilterSystem(_collidersRegistryService));
            entity.AddSystem(new DealDamageOnContactSystem());
            entity.AddSystem(new ApplyDamageSystem());
            entity.AddSystem(new DeathSystem());
            entity.AddSystem(new DisableCollidersOnDeathSystem());
            entity.AddSystem(new DeathProcessTimerSystem());
            entity.AddSystem(new SelfReleaseSystem(_entitiesLifeContext));

            return entity;
        }

        public Entity CreateRigidbodyEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/RigidbodyEntity");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(900));

            entity.AddSystem(new RigidbodyMovementSystem());
            entity.AddSystem(new RigidbodyRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateCharacterControllerEntity(Vector3 position)
        {
            Entity entity = CreateEmpty();

            _monoEntitiesFactory.Create(entity, position, "Entities/CharacterControllerEntity");

            entity
                .AddMoveDirection()
                .AddMoveSpeed(new ReactiveVariable<float>(10))
                .AddRotateDirection()
                .AddRotateSpeed(new ReactiveVariable<float>(900));

            entity.AddSystem(new CharacterControllerMovementSystem());
            entity.AddSystem(new TransformRotationSystem());

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Entity CreateEmpty() => new Entity();
    }
}

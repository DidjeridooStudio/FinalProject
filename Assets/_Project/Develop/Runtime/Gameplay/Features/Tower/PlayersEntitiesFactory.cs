using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Meta.Features.StatsUpgrade;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class PlayersEntitiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly BrainsFactory _brainsFactory;
        private readonly StatsUpgradeService _statsUpgradeService;

        public PlayersEntitiesFactory(DIContainer container, BrainsFactory brainsFactory)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsFactory = brainsFactory;
            _statsUpgradeService = _container.Resolve<StatsUpgradeService>();
        }

        public Entity CreateTower(GameLevelConfig config)
        {
            Entity entity = _entitiesFactory.CreateTowerEntity(config);

            entity.AddIsTower();

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreatePlayerEntity(Vector3 position, PlayerEntityConfig config)
        {
            Entity entity = _entitiesFactory.CreatePlayerEntity(position, config, GetStats());

            _brainsFactory.CreatePlayerEntityBrain(entity);

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateMineEntity(Vector3 position, MineEntityConfig config)
        {
            Entity entity = _entitiesFactory.CreateMineEntity(position, config);

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        public Entity CreateToxicPuddleEntity(Vector3 position, ToxicPuddleConfig config)
        {
            Entity entity = _entitiesFactory.CreateToxicPuddle(position, config);

            _entitiesLifeContext.Add(entity);

            _brainsFactory.CreateToxicPuddleEntityBrain(entity);

            return entity;
        }

        public Entity CreateTurretEntity(Vector3 position, TurretEntityConfig config)
        {
            Entity entity = _entitiesFactory.CreateTurretEntity(position, config);

            entity.AddCurrentTarget();
            entity.AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));

            _brainsFactory.CreateTurretEntityBrain(entity, new NearestDamageableTargetSelector(entity));

            _entitiesLifeContext.Add(entity);

            return entity;
        }

        private Dictionary<StatTypes, float> GetStats()
        {
            Dictionary<StatTypes, float> stats = new Dictionary<StatTypes, float>();

            foreach (StatTypes statType in Enum.GetValues(typeof(StatTypes)))
                stats.Add(statType, _statsUpgradeService.GetCurrentStatValueFor(statType));

            return stats;
        }
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class PlayersEntitiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;
        private readonly BrainsFactory _brainsFactory;

        public PlayersEntitiesFactory(DIContainer container, BrainsFactory brainsFactory)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsFactory = brainsFactory;
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
            Entity entity = _entitiesFactory.CreatePlayerEntity(position, config);

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
    }
}

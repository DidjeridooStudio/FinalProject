using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Enemies
{
    public class EnemiesFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public EnemiesFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position, EntityConfig config)
        {
            Entity entity;

            switch(config)
            {
                case GhostConfig ghostConfig:
                    entity = _entitiesFactory.CreateGhostEntity(position, ghostConfig);
                    _brainsFactory.CreateGhostBrain(entity);
                    break;
                case BlowEntityConfig blowEntityConfig:
                    entity = _entitiesFactory.CreateBlowEntity(position, blowEntityConfig);
                    _brainsFactory.CreateBlowEntityBrain(entity);
                    break;
                default:
                    throw new ArgumentException($"Not support {config.GetType()} type of configs");
            }

            entity.AddTeam(new ReactiveVariable<Teams>(Teams.Enemies));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}

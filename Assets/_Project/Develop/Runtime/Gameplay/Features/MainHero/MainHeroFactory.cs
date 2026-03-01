using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI.States;
using Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHero
{
    public class MainHeroFactory
    {
        private readonly DIContainer _container;

        private readonly EntitiesFactory _entitiesFactory;
        private readonly BrainsFactory _brainsFactory;
        private readonly ConfigsProviderService _configProviderService;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        public MainHeroFactory(DIContainer container)
        {
            _container = container;

            _entitiesFactory = _container.Resolve<EntitiesFactory>();
            _brainsFactory = _container.Resolve<BrainsFactory>();
            _configProviderService = container.Resolve<ConfigsProviderService>();
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
        }

        public Entity Create(Vector3 position)
        {
            HeroConfig config = _configProviderService.GetConfig<HeroConfig>();

            Entity entity = _entitiesFactory.CreateHeroEntity(position, config);

            entity.AddIsMainHero();
            entity.AddTeam(new ReactiveVariable<Teams>(Teams.MainHero));
            entity.AddCurrentTarget();

            _brainsFactory.CreateMainHeroBrain(entity, new NearestDamageableTargetSelector(entity));

            _entitiesLifeContext.Add(entity);

            return entity;
        }
    }
}

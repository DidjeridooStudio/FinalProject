using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using VSCodeEditor;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.MainHero
{
    public class MainHeroHolderService : IInitializable, IDisposable
    {
        private EntitiesLifeContext _entitiesLifeContext;
        private Entity _mainHero;

        private ReactiveEvent<Entity> _heroRegistered = new ReactiveEvent<Entity>();

        public MainHeroHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public Entity MainHero => _mainHero;

        public IReadOnlyEvent<Entity> HeroRegistered => _heroRegistered;

        public void Initialize()
        {
            _entitiesLifeContext.Added += OnEntityAdded;
        }

        public void Dispose()
        {
            _entitiesLifeContext.Added -= OnEntityAdded;
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.HasComponent<IsMainHero>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;
                _mainHero = entity;
                _heroRegistered?.Invoke(_mainHero);
            }
        }
    }
}

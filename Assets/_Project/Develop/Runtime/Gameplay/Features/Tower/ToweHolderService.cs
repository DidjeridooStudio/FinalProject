using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features
{
    public class ToweHolderService : IInitializable, IDisposable
    {
        private EntitiesLifeContext _entitiesLifeContext;
        private Entity _tower;

        private ReactiveEvent<Entity> _towerRegistered = new ReactiveEvent<Entity>();

        public ToweHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public Entity Tower => _tower;

        public IReadOnlyEvent<Entity> TowerRegistered => _towerRegistered;


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
            if (entity.HasComponent<IsTower>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;
                _tower = entity;
                _towerRegistered?.Invoke(_tower);
            }
        }
    }
}

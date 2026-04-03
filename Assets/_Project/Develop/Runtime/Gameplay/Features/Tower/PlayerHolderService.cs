using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class PlayerHolderService : IInitializable, IDisposable
    {
        private EntitiesLifeContext _entitiesLifeContext;
        private Entity _player;

        private ReactiveEvent<Entity> _playerRegistered = new ReactiveEvent<Entity>();

        public PlayerHolderService(EntitiesLifeContext entitiesLifeContext)
        {
            _entitiesLifeContext = entitiesLifeContext;
        }

        public Entity Player => _player;

        public IReadOnlyEvent<Entity> TowerRegistered => _playerRegistered;


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
            if (entity.HasComponent<IsPlayerEntity>())
            {
                _entitiesLifeContext.Added -= OnEntityAdded;
                _player = entity;
                _playerRegistered?.Invoke(_player);
            }
        }
    }
}

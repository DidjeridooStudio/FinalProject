using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.AssetsManagment;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono
{
    public class MonoEntitiesFactory : IInitializable, IDisposable
    {
        private readonly ResourcesAssetsLoader _resourcesAssetsLoader;
        private readonly EntitiesLifeContext _entitiesLifeContext;

        private readonly Dictionary<Entity, MonoEntity> _entityToMono = new Dictionary<Entity, MonoEntity>();

        public MonoEntitiesFactory(ResourcesAssetsLoader resourcesAssetsLoader, EntitiesLifeContext entitiesLifeContext)
        {
            _resourcesAssetsLoader = resourcesAssetsLoader;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public MonoEntity Create(Entity entity, Vector3 position, string path)
        {
            MonoEntity prefab = _resourcesAssetsLoader.Load<MonoEntity>(path);

            MonoEntity instance = Object.Instantiate(prefab, position, Quaternion.identity);

            instance.Setup(entity);

            _entityToMono.Add(entity, instance);

            return instance;
        }

        #region Interface

        public void Initialize()
        {
            _entitiesLifeContext.Released += OnEntityReleased;
        }

        public void Dispose()
        {
            _entitiesLifeContext.Released -= OnEntityReleased;

            foreach (Entity entity in _entityToMono.Keys)
                CleanupFor(entity);

            _entityToMono.Clear();
        }

        #endregion

        private void OnEntityReleased(Entity entity)
        {
            CleanupFor(entity);

            _entityToMono.Remove(entity);
        }

        private void CleanupFor(Entity entity)
        {
            MonoEntity monoEntity = _entityToMono[entity];

            monoEntity.Cleanup(entity);

            Object.Destroy(monoEntity.gameObject);
        }
    }
}

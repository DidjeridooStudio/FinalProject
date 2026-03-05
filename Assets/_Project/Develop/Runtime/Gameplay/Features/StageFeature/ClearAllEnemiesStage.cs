using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Enemies;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature
{
    public class ClearAllEnemiesStage : IStage
    {
        private ClearAllEnemiesStageConfig _config;
        private ReactiveEvent _completed = new ReactiveEvent();
        private EnemiesFactory _enemiesFactory;
        private EntitiesLifeContext _entitiesLifeContext;

        private bool _inProcess;

        private Dictionary<Entity, IDisposable> _spawnedEnemiesToRemoveReason = new Dictionary<Entity, IDisposable>();

        public ClearAllEnemiesStage(ClearAllEnemiesStageConfig config, EnemiesFactory enemiesFactory,
            EntitiesLifeContext entitiesLifeContext)
        {
            _config = config;
            _enemiesFactory = enemiesFactory;
            _entitiesLifeContext = entitiesLifeContext;
        }

        public IReadOnlyEvent Completed => _completed;

        public void Start()
        {
            if (_inProcess)
                throw new InvalidOperationException("Game mode already started");

            _inProcess = true;

            SpawnEnemies();
        }

        public void Update(float deltaTime)
        {
            if (_inProcess == false)
                return;

            if (_spawnedEnemiesToRemoveReason.Count == 0)
                ProcessEnd();
        }

        public void Cleanup()
        {
            foreach (var item in _spawnedEnemiesToRemoveReason)
            {
                item.Value.Dispose();
                _entitiesLifeContext.Release(item.Key);
            }

            _spawnedEnemiesToRemoveReason.Clear();

            _inProcess = false;
        }

        public void Dispose()
        {
            foreach (var item in _spawnedEnemiesToRemoveReason)
                item.Value.Dispose();

            _spawnedEnemiesToRemoveReason.Clear();

            _inProcess = false;
        }

        private void SpawnEnemies()
        {
            foreach (var itemConfig in _config.EnemyItems)
                SpawnEnemy(itemConfig);
        }

        private void SpawnEnemy(EnemyItemConfig itemConfig)
        {
            Entity spawnedEnemy = _enemiesFactory.Create(itemConfig.SpawnPosition, itemConfig.EnemyConfig);

            IDisposable removeReason = spawnedEnemy.IsDead.Subcribe((oldValue, isDead) =>
            {
                if (isDead)
                {
                    IDisposable disposable = _spawnedEnemiesToRemoveReason[spawnedEnemy];
                    disposable.Dispose();
                    _spawnedEnemiesToRemoveReason.Remove(spawnedEnemy);
                }
            });

            _spawnedEnemiesToRemoveReason.Add(spawnedEnemy, removeReason);
        }

        private void ProcessEnd()
        {
            _inProcess = false;
            _completed?.Invoke();
        }

        private void Blow()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                //_explodeEffect.transform.position = hitInfo.point;
                //_explodeEffect.Play();

                //Collider[] targets = Physics.OverlapSphere(hitInfo.point, 6);

                //foreach (Collider target in targets)
                //{
                //    if (target.TryGetComponent<Entity>(out Entity contactEntity))
                //    {
                //        if (contactEntity.HasComponent<TakeDamageRequest>())
                //            contactEntity.TakeDamageRequest.Invoke(50);

                //    }
                //}
            }
        }
    }
}

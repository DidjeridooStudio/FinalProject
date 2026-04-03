using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.HealthPresenter
{
    public class EntitiesHealthDisplayPresenter : IPresenter
    {
        private readonly EntitiesLifeContext _lifeContext;
        private readonly EntitiesHealthDisplay _view;
        private readonly GameplayPresentersFactory _presentersFactory;
        private readonly ViewsFactory _viewsFactory;

        private Dictionary<Entity, EntityHealthBarInfo> _entityToHealthBarInfo = new Dictionary<Entity, EntityHealthBarInfo>();

        public EntitiesHealthDisplayPresenter(EntitiesLifeContext lifeContext, EntitiesHealthDisplay view, GameplayPresentersFactory presentersFactory, ViewsFactory viewsFactory)
        {
            _lifeContext = lifeContext;
            _view = view;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
        }

        public void Initialize()
        {
            _lifeContext.Added += OnEntityAdded;
            _lifeContext.Released += OnEntityReleased;

            foreach (Entity entity in _lifeContext.Entities)
                OnEntityAdded(entity);
        }

        public void LateUpdate()
        {
            foreach (var info in _entityToHealthBarInfo)
                _view.UpdatePositionFor(info.Value.HealthPresenter.Bar, info.Value.HealthBarPoint.position);
        }

        public void Dispose()
        {
            _lifeContext.Added -= OnEntityAdded;
            _lifeContext.Released -= OnEntityReleased;

            foreach (EntityHealthBarInfo info in _entityToHealthBarInfo.Values)
                DisposeFor(info);

            _entityToHealthBarInfo.Clear();
        }

        private void OnEntityAdded(Entity entity)
        {
            if (entity.TryGetHealthBarPoint(out Transform healthBarPoint))
            {
                BarWithText view = null;

                if (entity.HasComponent<IsTower>())
                    view = _viewsFactory.Create<BarWithText>(ViewsIDs.HealthBar);
                else
                    view = _viewsFactory.Create<BarWithText>(ViewsIDs.SimpleHealthBar);

                _view.Add(view);

                EntityHealthPresenter presenter = _presentersFactory.CreateEntityHealthPresenter(entity, view);
                presenter.Initialize();

                IDisposable removeReason = entity.IsDead.Subcribe((oldValue, isDead) =>
                {
                    if (isDead)
                        RemoveHealthBarFor(entity);
                });

                _entityToHealthBarInfo.Add(entity, new EntityHealthBarInfo(healthBarPoint, removeReason, presenter));
            }
        }

        private void OnEntityReleased(Entity entity)
        {
            if (_entityToHealthBarInfo.ContainsKey(entity))
                RemoveHealthBarFor(entity);
        }

        private void RemoveHealthBarFor(Entity entity)
        {
            EntityHealthBarInfo info = _entityToHealthBarInfo[entity];
            DisposeFor(info);
            _entityToHealthBarInfo.Remove(entity);
        }

        private void DisposeFor(EntityHealthBarInfo info)
        {
            info.RemoveReason.Dispose();

            _view.Remove(info.HealthPresenter.Bar);
            _viewsFactory.Release(info.HealthPresenter.Bar);

            info.HealthPresenter.Dispose();
        }

        private class EntityHealthBarInfo
        {
            public EntityHealthBarInfo(Transform healthBarPoint, IDisposable removeReason, EntityHealthPresenter healthPresenter)
            {
                HealthBarPoint = healthBarPoint;
                RemoveReason = removeReason;
                HealthPresenter = healthPresenter;
            }

            public Transform HealthBarPoint { get; }
            public IDisposable RemoveReason { get; }
            public EntityHealthPresenter HealthPresenter { get; }
        }
    }
}

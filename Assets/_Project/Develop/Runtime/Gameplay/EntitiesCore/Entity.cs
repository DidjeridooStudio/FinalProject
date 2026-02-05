using Assets._Project.Develop.Runtime.Gameplay.Common;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Systems;
using Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
    public partial class Entity : IDisposable
    {
        private readonly Dictionary<Type, IEntityComponent> _components = new Dictionary<Type, IEntityComponent>();

        private readonly List<IEntitySystem> _systems = new List<IEntitySystem>();
        private readonly List<IInitializableSystem> _initializableSystems = new List<IInitializableSystem>();
        private readonly List<IUpdatableSystem> _updatableSystems = new List<IUpdatableSystem>();
        private readonly List<IDisposableSystem> _disposableSystems = new List<IDisposableSystem>();

        private bool _isInit;

        public void Initialize()
        {
            foreach (IInitializableSystem system in _initializableSystems)
                system.OnInit(this);

            _isInit = true;
        }

        public void OnUpdate(float deltaTime)
        {
            if (_isInit == false)
                return;

            foreach (IUpdatableSystem system in _updatableSystems)
                system.OnUpdate(deltaTime);
        }

        #region Interface

        public void Dispose()
        {
            foreach (IDisposableSystem system in _disposableSystems)
                system.OnDispose();

            _isInit = false;
        }

        #endregion

        public Entity AddComponent<TComponent>(TComponent component) where TComponent : class, IEntityComponent
        {
            _components.Add(typeof(TComponent), component);
            return this;
        }

        public bool TryGetComponent<TComponent>(out TComponent component) where TComponent : class, IEntityComponent
        {
            if (_components.TryGetValue(typeof(TComponent), out IEntityComponent findedComponent))
            {
                component = (TComponent)findedComponent;
                return true;
            }

            component = null;
            return false;
        }

        public TComponent GetComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            if (TryGetComponent(out TComponent component) == false)
                throw new ArgumentException($"Entity does not contain {typeof(TComponent)} component");

            return component;
        }

        public bool HasComponent<TComponent>() where TComponent : class, IEntityComponent
        {
            return _components.ContainsKey(typeof(TComponent));
        }

        public Entity AddSystem(IEntitySystem system)
        {
            if (_systems.Contains(system))
                throw new ArgumentException(system.GetType().ToString());

            _systems.Add(system);

            if (system is IInitializableSystem initializableSystem)
            {
                _initializableSystems.Add(initializableSystem);

                if (_isInit)
                    initializableSystem.OnInit(this);
            }

            if (system is IUpdatableSystem updatableSystem)
                _updatableSystems.Add(updatableSystem);

            if (system is IDisposableSystem disposableSystem)
                _disposableSystems.Add(disposableSystem);

            return this;
        }
    }
}

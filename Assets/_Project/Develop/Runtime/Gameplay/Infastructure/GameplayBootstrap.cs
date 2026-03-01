using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.AI;
using Assets._Project.Develop.Runtime.Gameplay.Features.Tower;
using Assets._Project.Develop.Runtime.Gameplay.States;
using Assets._Project.Develop.Runtime.Infastructure;
using Assets._Project.Develop.Runtime.Infastructure.DI;
using Assets._Project.Develop.Runtime.Utilies.ConfigsManagment;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets._Project.Develop.Runtime.Gameplay.Infastructure
{
    public class GameplayBootstrap : SceneBootstrap
    {
        private DIContainer _container;
        private GameplayInputArgs _inputArgs;

        private GameplayStatesContext _gameplayStatesContext;
        private EntitiesLifeContext _entitiesLifeContext;
        private AIBrainsContext _brainsContext;

        public override void ProcessRegistrations(DIContainer container, IInputSceneArgs sceneArgs = null)
        {
            _container = container;

            if (sceneArgs != null)
            {
                if (sceneArgs is not GameplayInputArgs gameplayInputArgs)
                    throw new ArgumentException($"{nameof(sceneArgs)} is not match with {typeof(GameplayInputArgs)} type");

                _inputArgs = gameplayInputArgs;
            }
            else
            {
                GameLevelsListConfig levelsListConfig = _container.Resolve<ConfigsProviderService>().GetConfig<GameLevelsListConfig>();

                GameLevelConfig levelConfig = levelsListConfig.LevelConfigs[Random.Range(0, levelsListConfig.LevelConfigs.Count)];

                _inputArgs = new GameplayInputArgs("", 1, 1, levelConfig);
            }

            GameplayContextRegistrations.Process(_container, _inputArgs);
        }

        public override IEnumerator Initialize()
        {
            _entitiesLifeContext = _container.Resolve<EntitiesLifeContext>();
            _brainsContext = _container.Resolve<AIBrainsContext>();
            _gameplayStatesContext = _container.Resolve<GameplayStatesContext>();

            PlayersEntitiesFactory playersEntitiesFactory = _container.Resolve<PlayersEntitiesFactory>();
            playersEntitiesFactory.CreateTower(_inputArgs.LevelConfig);
            playersEntitiesFactory.CreatePlayerEntity(Vector3.zero, _container.Resolve<ConfigsProviderService>().GetConfig<PlayerEntityConfig>());

            yield break;
        }

        public override void Run()
        {
            _gameplayStatesContext.Run();
        }

        private void Update()
        {
            _brainsContext?.Update(Time.deltaTime);
            _entitiesLifeContext?.Update(Time.deltaTime);
            _gameplayStatesContext?.Update(Time.deltaTime);
        }
    }
}
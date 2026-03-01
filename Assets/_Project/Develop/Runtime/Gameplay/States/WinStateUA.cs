using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class WinStateUA : EndGameState, IUpdatebableState
    {
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly ScenesSwitcherService _scenesSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;

        public WinStateUA(
            IInputService inputService,
            LevelsProgressionService levelsProgressionService,
            GameplayInputArgs gameplayInputArgs,
            PlayerDataProvider playerDataProvider,
            ScenesSwitcherService scenesSwitcherService,
            ICoroutinesPerformer coroutinesPerformer) : base(inputService)
        {
            _levelsProgressionService = levelsProgressionService;
            _gameplayInputArgs = gameplayInputArgs;
            _playerDataProvider = playerDataProvider;
            _scenesSwitcherService = scenesSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
        }

        public override void Enter()
        {
            base.Enter();

            _levelsProgressionService.AddLevelToCompleted(_gameplayInputArgs.LevelNumber);
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.Q))
                _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
        }
    }
}

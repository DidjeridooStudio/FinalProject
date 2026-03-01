using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatebableState
    {
        private readonly ScenesSwitcherService _scenesSwitcherService;
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly ProgressionService _progressionService;
        private readonly PlayerDataProvider _playerDataProvider;

        public DefeatState(
            IInputService inputService,
            ScenesSwitcherService scenesSwitcherService,
            ICoroutinesPerformer coroutinesPerformer,
            ProgressionService progressionService,
            PlayerDataProvider playerDataProvider) : base(inputService)
        {
            _scenesSwitcherService = scenesSwitcherService;
            _coroutinesPerformer = coroutinesPerformer;
            _progressionService = progressionService;
            _playerDataProvider = playerDataProvider;
        }

        public override void Enter()
        {
            base.Enter();

            Debug.Log("Loose");

            _progressionService.IncreaseLosses();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());
        }

        public void Update(float deltaTime)
        {
            if (Input.GetKeyDown(KeyCode.S))
                _coroutinesPerformer.StartPerform(_scenesSwitcherService.ProcessSwitchTo(Scenes.MainMenu));
        }
    }
}

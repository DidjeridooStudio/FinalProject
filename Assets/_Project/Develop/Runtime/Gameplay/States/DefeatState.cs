using Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature;
using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.UI.GamePlay;
using Assets._Project.Develop.Runtime.Utilies.CoroutinesManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using Assets._Project.Develop.Runtime.Utilies.StateMachineCore;

namespace Assets._Project.Develop.Runtime.Gameplay.States
{
    public class DefeatState : EndGameState, IUpdatebableState
    {
        private readonly ICoroutinesPerformer _coroutinesPerformer;
        private readonly ProgressionService _progressionService;
        private readonly PlayerDataProvider _playerDataProvider;
        private readonly GameplayPopupService _popupService;

        public DefeatState(
            IInputService inputService,
            ICoroutinesPerformer coroutinesPerformer,
            ProgressionService progressionService,
            PlayerDataProvider playerDataProvider,
            GameplayPopupService popupService) : base(inputService)
        {
            _coroutinesPerformer = coroutinesPerformer;
            _progressionService = progressionService;
            _playerDataProvider = playerDataProvider;
            _popupService = popupService;
        }

        public override void Enter()
        {
            base.Enter();

            _progressionService.IncreaseLosses();
            _coroutinesPerformer.StartPerform(_playerDataProvider.SaveAsync());

            _popupService.OpenDefeatPopup();
        }

        public void Update(float deltaTime)
        {
        }
    }
}

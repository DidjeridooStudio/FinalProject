using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StageFeature
{
    public class StageProviderService : IDisposable
    {
        private ReactiveVariable<int> _currentStageNumber = new ReactiveVariable<int>();
        private ReactiveVariable<StageResults> _currentStageResult = new ReactiveVariable<StageResults>();
        private GameLevelConfig _gameLevelConfig;
        private StagesFactory _stagesFactory;
        private IStage _currentStage;

        private IDisposable _stageEndedDisposable;

        public StageProviderService(GameLevelConfig gameLevelConfig, StagesFactory stagesFactory)
        {
            _gameLevelConfig = gameLevelConfig;
            _stagesFactory = stagesFactory;
        }

        public IReadOnlyVariable<int> CurrentStageNumber => _currentStageNumber;
        public IReadOnlyVariable<StageResults> CurrentStageResult => _currentStageResult;

        public int StagesCount => _gameLevelConfig.StageConfigs.Count;

        public bool HasNextStage() => CurrentStageNumber.Value < StagesCount;

        public void SwitchToNext()
        {
            if (HasNextStage() == false)
                throw new InvalidOperationException();

            if (_currentStage != null)
                CleanupCurrent();

            _currentStageNumber.Value++;
            _currentStageResult.Value = StageResults.Uncompleted;

            _currentStage = _stagesFactory.Create(_gameLevelConfig.StageConfigs[_currentStageNumber.Value - 1]);
        }

        public void StartCurrent()
        {
            _stageEndedDisposable = _currentStage.Completed.Subcribe(OnStageCompleted);
            _currentStage.Start();
        }

        public void UpdateCurrent(float deltaTime) => _currentStage.Update(deltaTime);
        public void CleanupCurrent() => _currentStage.Cleanup();
        public void Dispose()
        {
            _currentStage?.Dispose();
            _stageEndedDisposable?.Dispose();
        }

        private void OnStageCompleted()
        {
            _currentStageResult.Value = StageResults.Completed;
        }
    }
}

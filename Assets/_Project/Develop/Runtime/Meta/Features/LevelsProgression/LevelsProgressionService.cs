using Assets._Project.Develop.Runtime.Utilies.DataManagment;
using Assets._Project.Develop.Runtime.Utilies.DataManagment.DataProviders;
using System.Collections.Generic;
using System.Data;

namespace Assets._Project.Develop.Runtime.Meta.Features.LevelsProgression
{
    public class LevelsProgressionService : IDataReader<PlayerData>, IDataWriter<PlayerData>
    {
        private const int FirstLevel = 1;

        private readonly List<int> _completedLevels = new List<int>();

        public LevelsProgressionService(PlayerDataProvider playerDataProvider)
        {
            playerDataProvider.RegisterDataReader(this);
            playerDataProvider.RegisterDataWriters(this);
        }

        public bool IsLevelCompleted(int levelNumber) => _completedLevels.Contains(levelNumber);

        public void AddLevelToCompleted(int levelNumber)
        {
            if (IsLevelCompleted(levelNumber))
                return;

            _completedLevels.Add(levelNumber);
        }

        public bool CanPlay(int levelNumber) => levelNumber == FirstLevel || PreviousLevelComplete(levelNumber);

        #region Interface

        public void ReadFrom(PlayerData data)
        {
            _completedLevels.Clear();
            //_completedLevels.AddRange(data.CompletedLevels);
        }

        public void WriteTo(PlayerData data)
        {
            //data.CompletedLevels.Clear();
            //data.CompletedLevels.AddRange(_completedLevels);
        }

        #endregion

        private bool PreviousLevelComplete(int levelNumber) => IsLevelCompleted(levelNumber - 1);
    }
}

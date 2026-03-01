using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Game Levels List Config", fileName = "GameLevelsListConfig")]
    public class GameLevelsListConfig : ScriptableObject
    {
        [SerializeField] private List<GameLevelConfig> _levelConfigs;

        public IReadOnlyList<GameLevelConfig> LevelConfigs => _levelConfigs;
    }
}

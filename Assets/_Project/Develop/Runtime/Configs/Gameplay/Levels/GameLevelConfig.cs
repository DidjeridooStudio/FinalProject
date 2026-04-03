using Assets._Project.Develop.Runtime.Configs.Gameplay.Stages;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Levels
{
    [CreateAssetMenu(menuName = "Configs/Game Level Config", fileName = "GameLevelConfig")]
    public class GameLevelConfig : ScriptableObject
    {
        [field: SerializeField] public string TowerPrefabPath { get; private set; } = "Entities/TowerEntity";
        [field: SerializeField] public float TowerHealth { get; private set; }
        [field: SerializeField] public Vector3 TowerPosition { get; private set; }
        [field: SerializeField] public int GoldWinReward { get; private set; }
        [field: SerializeField] public int DiamondWinReward { get; private set; }

        [SerializeField] private List<StageConfig> _stageConfigs;

        public IReadOnlyList<StageConfig> StageConfigs => _stageConfigs;
    }
}

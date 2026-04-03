using Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta.Stats
{
    [CreateAssetMenu(menuName = "Configs/Stats View Config", fileName = "StatsViewConfig")]
    public class StatsViewConfig :ScriptableObject
    {
        [SerializeField] private List<StatViewConfig> _stats = new List<StatViewConfig>();

        public StatViewConfig GetStatViewData(StatTypes type) => _stats.First(stat => stat.Type == type);

        [Serializable]
        public class StatViewConfig
        {
            [field: SerializeField] public StatTypes Type { get; private set; }
            [field: SerializeField] public string Name { get; private set; }
            [field: SerializeField] public Sprite Sprite { get; private set; }
        }
    }
}

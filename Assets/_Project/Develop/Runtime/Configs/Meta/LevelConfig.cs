using Assets._Project.Develop.Runtime.Gameplay.Infastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta
{
    [CreateAssetMenu(menuName = "Configs/Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private List<ModeTypesConfig> _values;
        [field: SerializeField] public int SymbolsQuanity { get; private set; }
        [field: SerializeField] public int MoneyBet { get; private set; }

        public string GetValueFor(ModeTypes type) => _values.First(config => config.Type == type).SymbolSet;

        [Serializable]
        private class ModeTypesConfig
        {
            [field: SerializeField] public ModeTypes Type { get; private set; }
            [field: SerializeField] public string SymbolSet { get; private set; }
        }
    }
}
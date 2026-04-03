using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay.Abilities
{
    [CreateAssetMenu(menuName = "Configs/Abilities Configs Container", fileName = "AbilitiesConfigsContainer")]
    public class AbilitiesConfigsContainer : ScriptableObject
    {
        [SerializeField] private List<AbilityConfig> _abilities;

        public IReadOnlyList<AbilityConfig> Abilities => _abilities;

        public AbilityConfig GetConfigBy(string ID) => _abilities.First(config => config.ID == ID);
    }
}

using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta
{
    [CreateAssetMenu(menuName = "Configs/Standard Settings Config", fileName = "StandardSettingsConfig")]
    public class StandardSettingsConfig : ScriptableObject
    {
        [field: SerializeField] public int MoneyToResetProgress { get; private set; }
    }
}
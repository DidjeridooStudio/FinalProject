using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Meta
{
    [CreateAssetMenu(menuName = "Configs/Letters Config", fileName = "LettersConfig")]
    public class LettersConfig : ScriptableObject
    {
        [field: SerializeField] public string SymbolSet { get; private set; }
    }
}
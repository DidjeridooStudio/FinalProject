using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Numbers Config", fileName = "NumbersConfig")]
public class NumbersConfig : ScriptableObject
{
    [field: SerializeField] public string SymbolSet { get; private set; }
}

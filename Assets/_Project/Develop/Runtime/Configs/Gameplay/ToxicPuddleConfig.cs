using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Toxic Puddle Config", fileName = "ToxicPuddleConfig")]
    public class ToxicPuddleConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/ToxicPuddleEntity";
        [field: SerializeField, Min(0)] public float Damage { get; private set; } = 10;
        [field: SerializeField, Min(0)] public int SpawnPrice { get; private set; } = 5;
    }
}

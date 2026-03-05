using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Mine Entity Config", fileName = "MineEntityConfig")]
    public class MineEntityConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/MineEntity";
        [field: SerializeField, Min(0)] public float BlowRadius { get; private set; } = 4;
        [field: SerializeField, Min(0)] public float BlowDamage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
    }
}

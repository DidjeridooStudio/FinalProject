using Assets._Project.Develop.Runtime.Gameplay.Features.Blow;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Player Entity Config", fileName = "PlayerEntityConfig")]
    public class PlayerEntityConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/PlayerEntity";
        [field: SerializeField, Min(0)] public float BlowRadius { get; private set; } = 6;
        [field: SerializeField, Min(0)] public float BlowDamage { get; private set; } = 50;
        [field: SerializeField] public Mine MinePrefab { get; private set; }
        [field: SerializeField, Min(0)] public int MinePrice { get; private set; } = 50;
    }
}

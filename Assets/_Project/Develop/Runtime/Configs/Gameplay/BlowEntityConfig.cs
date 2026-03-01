using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Blow Entity Config", fileName = "BlowEntityConfig")]
    public class BlowEntityConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/BlowEntity";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 9;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float BlowRadius { get; private set; } = 4;
        [field: SerializeField, Min(0)] public float BlowDamage { get; private set; } = 50;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
    }
}
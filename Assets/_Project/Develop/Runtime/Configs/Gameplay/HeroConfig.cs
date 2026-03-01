using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Hero Config", fileName = "HeroConfig")]
    public class HeroConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/HeroEntity";
        [field: SerializeField, Min(0)] public float MoveSpeed { get; private set; } = 9;
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float MaxHealth { get; private set; } = 100;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public float AttackProcessTime { get; private set; } = 1.5f;
        [field: SerializeField, Min(0)] public float AttackDelayTime { get; private set; } = 0.75f;
        [field: SerializeField, Min(0)] public float AttackCooldown { get; private set; } = 1;
        [field: SerializeField, Min(0)] public float InstantAttackDamage { get; private set; } = 50;
    }
}

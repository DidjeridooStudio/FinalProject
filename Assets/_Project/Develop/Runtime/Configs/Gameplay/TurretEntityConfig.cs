using UnityEngine;

namespace Assets._Project.Develop.Runtime.Configs.Gameplay
{
    [CreateAssetMenu(menuName = "Configs/Turret Entity Config", fileName = "TurretEntityConfig")]
    public class TurretEntityConfig : EntityConfig
    {
        [field: SerializeField] public string PrefabPath { get; private set; } = "Entities/TurretEntity";
        [field: SerializeField, Min(0)] public float RotationSpeed { get; private set; } = 900;
        [field: SerializeField, Min(0)] public float AttackProcessTime { get; private set; } = 1f;
        [field: SerializeField, Min(0)] public float AttackDelayTime { get; private set; } = 0.5f;
        [field: SerializeField, Min(0)] public float AttackCooldown { get; private set; } = 0.75f;
        [field: SerializeField, Min(0)] public float Damage { get; private set; } = 30;
        [field: SerializeField, Min(0)] public float DeathProcessTime { get; private set; } = 2;
        [field: SerializeField, Min(0)] public int SpawnPrice { get; private set; } = 15;
    }
}

using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Tower
{
    public class IsTower : IEntityComponent
    {
    }

    public class IsPlayerEntity : IEntityComponent
    {
    }

    public class TowerHealRequest : IEntityComponent
    {
        public ReactiveEvent<Entity> Value;
    }

    public class TowerHealEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class StartClearAllEnemiesStageEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class EndClearAllEnemiesStageEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class IsClearAfterStage : IEntityComponent
    {
    }

    public class ProtectionObjectConfig : IEntityComponent
    {
        public ReactiveVariable<EntityConfig> Value;
    }
}

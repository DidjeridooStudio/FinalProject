using Assets._Project.Develop.Runtime.Configs.Gameplay;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class BlowDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class BlowRequest : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }

    public class BlowEvent : IEntityComponent
    {
        public ReactiveEvent<Vector3> Value;
    }

    public class BlowContactsDetectingEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class BlowEffectComponent : IEntityComponent
    {
        public ParticleSystem Value;
    }

    public class MineSpawnRequest : IEntityComponent
    {
        public ReactiveEvent<EntityConfig> Value;
    }
}

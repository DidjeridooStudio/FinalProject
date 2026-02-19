using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.TeleportFeature
{
    public class TeleportationRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportationDamage : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportationDamageRadius : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class TeleportCastRequest : IEntityComponent
    {
        public ReactiveEvent<float, Vector3> Value;
    }

    public class TeleportCastEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }

    public class TeleportContactsDetectingEvent : IEntityComponent
    {
        public ReactiveEvent Value;
    }
}

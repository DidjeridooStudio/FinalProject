using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature
{
    public class RotateDirection : IEntityComponent
    {
        public ReactiveVariable<Vector3> Value;
    }

    public class RotateSpeed : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class CanRotate : IEntityComponent
    {
        public ICompositeCondition Value;
    }
}

using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using Assets._Project.Develop.Runtime.Utilies.Reactive;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.L_5.EnergyFeature
{
    public class CurrentEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class MaxEnergy : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyRefillProcessInitialTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }

    public class EnergyRefillProcessCurrentTime : IEntityComponent
    {
        public ReactiveVariable<float> Value;
    }
    public class InEnergyRefillProcess : IEntityComponent
    {
        public ReactiveVariable<bool> Value;
    }
}

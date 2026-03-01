using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Mono;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.Blow
{
    public class BlowEffectEntityRegistrator : MonoEntityRegistrator
    {
        [SerializeField] private ParticleSystem _effect;

        public override void Register(Entity entity)
        {
            entity.AddBlowEffect(_effect);
        }
    }
}

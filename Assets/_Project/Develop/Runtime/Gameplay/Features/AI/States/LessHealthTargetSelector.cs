using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class LessHealthTargetSelector : ITargetSelector
    {
        private Entity _sources;

        public LessHealthTargetSelector(Entity entity)
        {
            _sources = entity;
        }

        public Entity SelectTargetFrom(IEnumerable<Entity> targets)
        {
            IEnumerable<Entity> selectedTargets = targets.Where(target =>
            {
                bool result = target.HasComponent<TakeDamageRequest>();

                if (target.TryGetCanApplyDamage(out ICompositeCondition canApplyDamage))
                {
                    result = result && canApplyDamage.Evaluate();
                }

                result = result && (target != _sources);

                return result;
            });

            if (selectedTargets.Any() == false)
                return null;

            Entity closestTarget = selectedTargets.First();
            float minTargetHealth = closestTarget.CurrentHealth.Value;

            foreach (Entity target in selectedTargets)
            {
                float targetHealth = target.CurrentHealth.Value;
                if (targetHealth < minTargetHealth)
                {
                    minTargetHealth = targetHealth;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }
    }
}

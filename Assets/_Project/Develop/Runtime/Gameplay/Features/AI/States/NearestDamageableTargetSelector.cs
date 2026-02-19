using Assets._Project.Develop.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Develop.Runtime.Gameplay.Features.ApplyDamage;
using Assets._Project.Develop.Runtime.Utilies.Conditions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AI.States
{
    public class NearestDamageableTargetSelector : ITargetSelector
    {
        private Entity _sources;
        private Transform _sourcesTransform;

        public NearestDamageableTargetSelector(Entity entity)
        {
            _sources = entity;
            _sourcesTransform = entity.Transform;
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
            float minDistance = GetDistanceTo(closestTarget);

            foreach (Entity target in selectedTargets)
            {
                float distance = GetDistanceTo(target);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }

            return closestTarget;
        }

        private float GetDistanceTo(Entity target) => (_sourcesTransform.position - target.Transform.position).magnitude;
    }
}

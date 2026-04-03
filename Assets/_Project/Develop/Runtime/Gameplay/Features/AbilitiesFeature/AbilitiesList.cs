using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.AbilitiesFeature
{
    public class AbilitiesList
    {
        public event Action<Ability> Added;

        private List<Ability> _abilities = new List<Ability>();

        public IReadOnlyList<Ability> Abilities => _abilities;

        public virtual void Add(Ability ability)
        {
            _abilities.Add(ability);
            Added?.Invoke(ability);
        }
    }
}

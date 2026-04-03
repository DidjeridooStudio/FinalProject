using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Gameplay.Features.StatsFeature
{
    public class StatsEffectsList
    {
        public event Action<IStatsEffect> Added;
        public event Action<IStatsEffect> Removed;

        private List<IStatsEffect> _elements = new List<IStatsEffect>();

        public IReadOnlyList<IStatsEffect> Elements => _elements;

        public virtual void Add(IStatsEffect effect)
        {
            _elements.Add(effect);
            Added?.Invoke(effect);
        }

        public virtual void Remove(IStatsEffect effect)
        {
            _elements.Remove(effect);
            Removed?.Invoke(effect);
        }
    }
}

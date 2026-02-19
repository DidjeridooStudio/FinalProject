using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilies.Reactive
{
    public class ReactiveEvent : IReadOnlyEvent
    {
        private readonly List<Subcriber> _subcribers = new List<Subcriber>();
        private readonly List<Subcriber> _toAdd = new List<Subcriber>();
        private readonly List<Subcriber> _toRemove = new List<Subcriber>();

        public IDisposable Subcribe(Action action)
        {
            Subcriber subcriber = new Subcriber(action, Remove);
            _toAdd.Add(subcriber);

            return subcriber;
        }

        public void Invoke()
        {
            if (_toAdd.Count > 0)
            {
                _subcribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subcriber subcriber in _toRemove)
                    _subcribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subcriber subcriber in _subcribers)
                subcriber.Invoke();
        }

        private void Remove(Subcriber subcriber) => _toRemove.Add(subcriber);
    }

    public class ReactiveEvent<T> : IReadOnlyEvent<T>
    {
        private readonly List<Subcriber<T>> _subcribers = new List<Subcriber<T>>();
        private readonly List<Subcriber<T>> _toAdd = new List<Subcriber<T>>();
        private readonly List<Subcriber<T>> _toRemove = new List<Subcriber<T>>();

        public IDisposable Subcribe(Action<T> action)
        {
            Subcriber<T> subcriber = new Subcriber<T>(action, Remove);
            _toAdd.Add(subcriber);

            return subcriber;
        }

        public void Invoke(T arg)
        {
            if (_toAdd.Count > 0)
            {
                _subcribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subcriber<T> subcriber in _toRemove)
                    _subcribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subcriber<T> subcriber in _subcribers)
                subcriber.Invoke(arg);
        }

        private void Remove(Subcriber<T> subcriber) => _toRemove.Add(subcriber);
    }

    public class ReactiveEvent<T, K> : IReadOnlyEvent<T, K>
    {
        private readonly List<Subcriber<T, K>> _subcribers = new List<Subcriber<T, K>>();
        private readonly List<Subcriber<T, K>> _toAdd = new List<Subcriber<T, K>>();
        private readonly List<Subcriber<T, K>> _toRemove = new List<Subcriber<T, K>>();

        public IDisposable Subcribe(Action<T, K> action)
        {
            Subcriber<T, K> subcriber = new Subcriber<T, K>(action, Remove);
            _toAdd.Add(subcriber);

            return subcriber;
        }

        public void Invoke(T arg1, K arg2)
        {
            if (_toAdd.Count > 0)
            {
                _subcribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subcriber<T, K> subcriber in _toRemove)
                    _subcribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subcriber<T, K> subcriber in _subcribers)
                subcriber.Invoke(arg1, arg2);
        }

        private void Remove(Subcriber<T, K> subcriber) => _toRemove.Add(subcriber);
    }
}

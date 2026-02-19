using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.Utilies.Reactive
{
    public class ReactiveVariable<T> : IReadOnlyVariable<T>
    {
        private readonly List<Subcriber<T, T>> _subcribers = new List<Subcriber<T, T>>();
        private readonly List<Subcriber<T, T>> _toAdd = new List<Subcriber<T, T>>();
        private readonly List<Subcriber<T, T>> _toRemove = new List<Subcriber<T, T>>();

        private T _value;
        private IEqualityComparer<T> _comparer;

        public ReactiveVariable() : this(default) { }
        public ReactiveVariable(T value) : this(value, EqualityComparer<T>.Default) { }
        public ReactiveVariable(T value, IEqualityComparer<T> comparer)
        {
            _value = value;
            _comparer = comparer;
        }

        public T Value
        {
            get => _value;
            set
            {
                T oldValue = _value;

                _value = value;

                if (_comparer.Equals(oldValue, value) == false)
                    Invoke(oldValue, value);
            }
        }

        public IDisposable Subcribe(Action<T, T> action)
        {
            Subcriber<T, T> subcriber = new Subcriber<T, T>(action, Remove);
            _toAdd.Add(subcriber);

            return subcriber;
        }

        private void Remove(Subcriber<T, T> subcriber) => _toRemove.Add(subcriber);

        private void Invoke(T oldValue, T newValue)
        {
            if (_toAdd.Count > 0)
            {
                _subcribers.AddRange(_toAdd);
                _toAdd.Clear();
            }

            if (_toRemove.Count > 0)
            {
                foreach (Subcriber<T, T> subcriber in _toRemove)
                    _subcribers.Remove(subcriber);

                _toRemove.Clear();
            }

            foreach (Subcriber<T, T> subcriber in _subcribers)
                subcriber.Invoke(oldValue, newValue);
        }
    }
}
using System;
using System.Collections.Generic;

public class ReactiveVariable<T> : IReadOnlyVariable<T> where T : IEquatable<T>
{
    private readonly List<Subcriber<T, T>> _subcribers = new List<Subcriber<T, T>>();
    private readonly List<Subcriber<T, T>> _toAdd = new List<Subcriber<T, T>>();
    private readonly List<Subcriber<T, T>> _toRemove = new List<Subcriber<T, T>>();

    private T _value;

    public ReactiveVariable() => _value = default;
    public ReactiveVariable(T value) => _value = value;

    public T Value
    {
        get => _value;
        set
        {
            T oldValue = _value;

            _value = value;

            if (_value.Equals(oldValue) == false)
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

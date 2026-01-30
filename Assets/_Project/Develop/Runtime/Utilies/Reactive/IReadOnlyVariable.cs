using System;

namespace Assets._Project.Develop.Runtime.Utilies.Reactive
{
    public interface IReadOnlyVariable<T>
    {
        T Value { get; }

        IDisposable Subcribe(Action<T, T> action);
    }
}
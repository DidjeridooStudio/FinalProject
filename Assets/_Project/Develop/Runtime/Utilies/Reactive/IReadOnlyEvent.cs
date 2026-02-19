using System;

namespace Assets._Project.Develop.Runtime.Utilies.Reactive
{
    public interface IReadOnlyEvent
    {
        IDisposable Subcribe(Action action);
    }

    public interface IReadOnlyEvent<T>
    {
        IDisposable Subcribe(Action<T> action);
    }

    public interface IReadOnlyEvent<T, K>
    {
        IDisposable Subcribe(Action<T, K> action);
    }
}
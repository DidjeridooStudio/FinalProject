using System;

public interface IReadOnlyVariable<T>
{
    T Value { get; }

    IDisposable Subcribe(Action<T, T> action);
}

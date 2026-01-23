using System;

public class Subcriber<T, K> : IDisposable
{
    private Action<T, K> _action;
    private Action<Subcriber<T, K>> _onDispose;

    public Subcriber(Action<T, K> action, Action<Subcriber<T, K>> onDispose)
    {
        _action = action;
        _onDispose = onDispose;
    }

    public void Invoke(T arg1, K arg2) => _action?.Invoke(arg1, arg2);

    #region Interface

    public void Dispose() => _onDispose?.Invoke(this);

    #endregion
}

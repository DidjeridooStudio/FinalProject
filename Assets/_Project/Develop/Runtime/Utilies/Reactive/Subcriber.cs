using System;

namespace Assets._Project.Develop.Runtime.Utilies.Reactive
{
    public class Subcriber : IDisposable
    {
        private Action _action;
        private Action<Subcriber> _onDispose;

        public Subcriber(Action action, Action<Subcriber> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke() => _action?.Invoke();

        #region Interface

        public void Dispose() => _onDispose?.Invoke(this);

        #endregion
    }

    public class Subcriber<T> : IDisposable
    {
        private Action<T> _action;
        private Action<Subcriber<T>> _onDispose;

        public Subcriber(Action<T> action, Action<Subcriber<T>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke(T arg1) => _action?.Invoke(arg1);

        #region Interface

        public void Dispose() => _onDispose?.Invoke(this);

        #endregion
    }

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
}
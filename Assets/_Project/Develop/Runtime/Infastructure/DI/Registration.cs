using System;

public class Registration
{
    private Func<DIContainer, object> _creator;
    private object _cashedInstance;

    public Registration(Func<DIContainer, object> creator) => _creator = creator;

    public object CreateInstanceFrom(DIContainer container)
    {
        if (_cashedInstance != null)
            return _cashedInstance;

        if (_creator == null)
            throw new InvalidOperationException("Not has instance or creator");

        _cashedInstance = _creator.Invoke(container);

        return _cashedInstance;
    }
}
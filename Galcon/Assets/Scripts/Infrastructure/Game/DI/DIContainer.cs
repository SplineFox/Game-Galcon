using System;
using System.Collections.Generic;

public class DIContainer
{
    private readonly Dictionary<Type, object> _instances;

    public DIContainer()
    {
        _instances = new Dictionary<Type, object>();
    }

    public void Register<T>(T instance)
    {
        _instances.Add(typeof(T), instance);
    }

    public T Resolve<T>()
    {
        if (_instances.TryGetValue(typeof(T), out object instance))
            return (T)instance;

        throw new InvalidOperationException($"Dependency \"{typeof(T)}\" not found");
    }
}
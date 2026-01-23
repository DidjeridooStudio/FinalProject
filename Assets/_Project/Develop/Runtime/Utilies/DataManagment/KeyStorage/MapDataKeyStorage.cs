using System;
using System.Collections.Generic;

public class MapDataKeyStorage : IDataKeyStorage
{
    private readonly Dictionary<Type, string> _keys = new Dictionary<Type, string>()
    {
        {typeof(PlayerData), "PlayerData"},
    };

    #region Interface

    public string GetKeyFor<TData>() where TData : ISaveData => _keys[typeof(TData)];

    #endregion
}

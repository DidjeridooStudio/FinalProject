using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadService : ISaveLoadService
{
    private readonly IDataSerializer _serializer;
    private readonly IDataKeyStorage _keyStorage;
    private readonly IDataRepository _repository;

    public SaveLoadService(IDataSerializer serializer, IDataKeyStorage keyStorage, IDataRepository repository)
    {
        _serializer = serializer;
        _keyStorage = keyStorage;
        _repository = repository;
    }

    #region Interface

    public IEnumerator Exists<TData>(Action<bool> onExistsResult) where TData : ISaveData
    {
        string key = _keyStorage.GetKeyFor<TData>();

        yield return _repository.Exists(key, result => onExistsResult?.Invoke(result));
    }

    public IEnumerator Load<TData>(Action<TData> onLoad) where TData : ISaveData
    {
        string key = _keyStorage.GetKeyFor<TData>();
        string serializedData = String.Empty;
        
        yield return _repository.Read(key, result => serializedData = result);

        TData data = _serializer.Deserialize<TData>(serializedData);

        onLoad?.Invoke(data);
    }

    public IEnumerator Save<TData>(TData data) where TData : ISaveData
    {
        string serializedData = _serializer.Serialize(data);
        string key = _keyStorage.GetKeyFor<TData>();

        yield return _repository.Write(key, serializedData);
    }

    public IEnumerator Remove<TData>() where TData : ISaveData
    {
        string key = _keyStorage.GetKeyFor<TData>();

        yield return _repository.Remove(key);
    }

    #endregion
}

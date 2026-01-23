using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDataRepository : IDataRepository
{
    #region Interface

    public IEnumerator Exists(string key, Action<bool> onExistsResult)
    {
        bool exists = PlayerPrefs.HasKey(key);

        onExistsResult?.Invoke(exists);

        yield break;
    }

    public IEnumerator Read(string key, Action<string> onRead)
    {
        string serializedData = PlayerPrefs.GetString(key);

        onRead?.Invoke(serializedData);

        yield break;
    }

    public IEnumerator Write(string key, string serializedData)
    {
        PlayerPrefs.SetString(key, serializedData);

        yield break;
    }

    public IEnumerator Remove(string key)
    {
        PlayerPrefs.DeleteKey(key);

        yield break;
    }

    #endregion
}

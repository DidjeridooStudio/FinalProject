using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartLoadingScreen : MonoBehaviour, ILoadingScreen
{
    #region Interface

    public bool IsShown => gameObject.activeSelf;

    #endregion

    private void Awake()
    {
        Hide();
        DontDestroyOnLoad(this);
    }

    #region Interface

    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    #endregion
}

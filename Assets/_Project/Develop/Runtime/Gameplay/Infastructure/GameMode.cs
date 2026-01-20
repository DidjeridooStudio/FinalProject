using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMode
{
    private const int SymbolsQuanity = 6;

    public event Action Victory;
    public event Action Defeat;

    private string _symbolSet;
    private string _userString = String.Empty;
    private string _randomString= String.Empty;

    private bool _isRunning;

    public bool IsRunning => _isRunning;

    public GameMode(string symbolSet)
    {
        _symbolSet = symbolSet;
    }

    public void Start()
    {
        _isRunning = true;

        GenerateRandomString();
    }

    public void Update(float deltatime)
    {
        if (_isRunning == false)
            return;

        ReadUserInput();

        if (_userString.Length != SymbolsQuanity)
            return;

        Debug.Log("Вы ввели" + _userString);

        if (_userString == _randomString)
            ProcessVictory();
        else
            ProcessDefeat();

    }

    private void GenerateRandomString()
    {
        _randomString = string.Empty;

        for (int i = 0; i < SymbolsQuanity; i++)
            _randomString += _symbolSet[Random.Range(0, _symbolSet.Length)];

        Debug.Log(_randomString);
    }

    private void ReadUserInput()
    {
        foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(kcode))
                _userString += KeycodeToKeyString(kcode);
        }
    }

    private string KeycodeToKeyString(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.Alpha0:
                return "0";
            case KeyCode.Alpha1:
                return "1";
            case KeyCode.Alpha2:
                return "2";
            case KeyCode.Alpha3:
                return "3";
            case KeyCode.Alpha4:
                return "4";
            case KeyCode.Alpha5:
                return "5";
            case KeyCode.Alpha6:
                return "6";
            case KeyCode.Alpha7:
                return "7";
            case KeyCode.Alpha8:
                return "8";
            case KeyCode.Alpha9:
                return "9";
            default:
                return keyCode.ToString();
        }
    }

    private void ProcessVictory()
    {
        ProcessEndGame();
        Victory?.Invoke();
    }

    private void ProcessDefeat()
    {
        ProcessEndGame();
        Defeat?.Invoke();
    }

    private void ProcessEndGame()
    {
        _isRunning = false;
    }
}

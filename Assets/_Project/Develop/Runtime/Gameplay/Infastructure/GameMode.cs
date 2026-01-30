using Assets._Project.Develop.Runtime.Gameplay.Utilities;
using System;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Infastructure
{
    public class GameMode
    {
        public event Action Victory;
        public event Action Defeat;

        private GenerateRandomStringService _generateRandomStringService;
        private ReadUserInputService _userInputService;
        private int _symbolsQuanity;

        private string _userString = string.Empty;
        private string _randomString = string.Empty;

        private bool _isRunning;

        public bool IsRunning => _isRunning;

        public GameMode(GenerateRandomStringService generateRandomStringService, ReadUserInputService userInputService, int symbolsQuanity)
        {
            _generateRandomStringService = generateRandomStringService;
            _userInputService = userInputService;
            _symbolsQuanity = symbolsQuanity;
        }

        public void Start()
        {
            _isRunning = true;

            _randomString = _generateRandomStringService.Generate();

            Debug.Log(_randomString);
        }

        public void Update(float deltatime)
        {
            if (_isRunning == false)
                return;

            _userString = _userInputService.Read();

            if (_userString.Length < _symbolsQuanity)
                return;

            Debug.Log("Вы ввели " + _userString);

            if (_userString == _randomString)
                ProcessVictory();
            else
                ProcessDefeat();
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
}
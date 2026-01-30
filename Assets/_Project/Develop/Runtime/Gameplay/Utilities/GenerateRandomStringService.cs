using UnityEngine;

namespace Assets._Project.Develop.Runtime.Gameplay.Utilities
{
    public class GenerateRandomStringService
    {
        private string _symbolSet;
        private int _symbolsQuanity;

        private string _randomString;

        public GenerateRandomStringService(string symbolSet, int symbolsQuanity)
        {
            _symbolSet = symbolSet;
            _symbolsQuanity = symbolsQuanity;
        }

        public string Generate()
        {
            _randomString = string.Empty;

            for (int i = 0; i < _symbolsQuanity; i++)
                _randomString += _symbolSet[Random.Range(0, _symbolSet.Length)];

            return _randomString;
        }
    }
}
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.GamePlay
{
    public class GameplayScreenView : MonoBehaviour, IView
    {
        public event Action<string> CheckButtonClicked;

        [SerializeField] private TMP_Text _randomString;
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _checkButton;

        public void SetRandomString(string text) => _randomString.text = text;

        private void OnEnable()
        {
            _checkButton.onClick.AddListener(OnCheckButtonClicked);
        }

        private void OnDisable()
        {
            _checkButton.onClick.AddListener(OnCheckButtonClicked);
        }

        private void OnCheckButtonClicked() => CheckButtonClicked?.Invoke(_inputField.text);
    }
}

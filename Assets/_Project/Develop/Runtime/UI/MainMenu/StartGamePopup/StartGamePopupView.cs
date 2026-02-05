using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core.StartGamePopup
{
    public class StartGamePopupView : PopupViewBase
    {
        public event Action NumbersModeButtonClicked;
        public event Action LettersModeButtonClicked;

        [SerializeField] private Button _numbersModeButton;
        [SerializeField] private Button _lettersModeButton;

        private void OnEnable()
        {
            _numbersModeButton.onClick.AddListener(OnNumbersModeButtonClick);
            _lettersModeButton.onClick.AddListener(OnLettersModeButtonClick);
        }

        private void OnDisable()
        {
            _numbersModeButton.onClick.RemoveListener(OnNumbersModeButtonClick);
            _lettersModeButton.onClick.RemoveListener(OnLettersModeButtonClick);
        }

        private void OnNumbersModeButtonClick() => NumbersModeButtonClicked?.Invoke();

        private void OnLettersModeButtonClick() => LettersModeButtonClicked?.Invoke();
    }
}

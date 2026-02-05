using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core.ResetProgressPopup
{
    public class ResetProgressPopupView : PopupViewBase
    {
        public event Action ConfirmButtonClicked;
        public event Action CancelButtonClicked;

        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private Button _cancelButton;
        
        public void SetTitle(string title) => _title.text = title;

        private void OnEnable()
        {
            _confirmButton.onClick.AddListener(OnConfirmButtonClick);
            _cancelButton.onClick.AddListener(OnCancelButtonClick);
        }

        private void OnDisable()
        {
            _confirmButton.onClick.RemoveListener(OnConfirmButtonClick);
            _cancelButton.onClick.RemoveListener(OnCancelButtonClick);
        }

        private void OnConfirmButtonClick() => ConfirmButtonClicked?.Invoke();

        private void OnCancelButtonClick() => CancelButtonClicked?.Invoke();
    }
}
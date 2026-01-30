using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.Core.CheckProgressPopup
{
    public class CheckProgressPopupView : PopupViewBase
    {
        public event Action OKButtonClicked;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _OKButton;

        public void SetText(string text) => _text.text = text;

        private void OnEnable()
        {
            _OKButton.onClick.AddListener(OnOKButtonClick);
        }

        private void OnDisable()
        {
            _OKButton.onClick.RemoveListener(OnOKButtonClick);
        }

        private void OnOKButtonClick() => OKButtonClicked?.Invoke();
    }
}

using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.ResultsPopups
{
    public class WinPopupView : PopupViewBase
    {
        public event Action ContinueClicked;

        [SerializeField] private TMP_Text _title;

        public void SetTitle(string title) => _title.text = title;

        public void OnContinueClick() => ContinueClicked?.Invoke();
    }
}

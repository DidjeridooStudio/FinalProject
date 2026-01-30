using Assets._Project.Develop.Runtime.UI.Core;
using TMPro;
using UnityEngine;

namespace Assets._Project.Develop.Runtime.UI.CommonViews
{
    public class ProgressionView : MonoBehaviour, IView
    {
        [SerializeField] private TMP_Text _winningsText;
        [SerializeField] private TMP_Text _lossesText;

        public void SetWinningsText(string text) => _winningsText.text = text;

        public void SetLossesText(string text) => _lossesText.text = text;
    }
}
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.GamePlay.PreparationStatePopup
{
    public class PreparationStatePopupView : PopupViewBase
    {
        public event Action MineButtonClicked;
        public event Action ToxicPuddleButtonClicked;
        public event Action TurretButtonClicked;

        [SerializeField] private TMP_Text _text;
        [SerializeField] private Button _mineButton;
        [SerializeField] private Button _toxicPuddleButton;
        [SerializeField] private Button _turretButton;

        public void SetTitle(string title) => _text.text = title;

        private void OnEnable()
        {
            _mineButton.onClick.AddListener(OnMineButtonClick);
            _toxicPuddleButton.onClick.AddListener(OnToxicPuddleButtonClicked);
            _turretButton.onClick.AddListener(OnTurretButtonClicked);
        }

        private void OnDisable()
        {
            _mineButton.onClick.RemoveListener(OnMineButtonClick);
            _toxicPuddleButton.onClick.RemoveListener(OnToxicPuddleButtonClicked);
            _turretButton.onClick.RemoveListener(OnTurretButtonClicked);
        }

        private void OnMineButtonClick() => MineButtonClicked?.Invoke();
        private void OnToxicPuddleButtonClicked() => ToxicPuddleButtonClicked?.Invoke();
        private void OnTurretButtonClicked() => TurretButtonClicked?.Invoke();
    }
}

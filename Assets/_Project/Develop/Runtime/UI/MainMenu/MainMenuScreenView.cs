using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets._Project.Develop.Runtime.UI.MainMenu
{
    public class MainMenuScreenView : MonoBehaviour, IView
    {
        public event Action OpenPopupStartGameButtonClicked;
        public event Action OpenPopupResetProgressClicked;
        public event Action OpenStatsUpgradeButtonClicked;

        [field: SerializeField] public IconTextListView WalletView {  get; private set; }
        [field: SerializeField] public ProgressionView ProgressionView {  get; private set; }

        [SerializeField] private Button _openPopupStartGameButton;
        [SerializeField] private Button _openPopupResetProgressButton;
        [SerializeField] private Button _openStatsUpgradeButton;

        private void OnEnable()
        {
            _openPopupStartGameButton.onClick.AddListener(OnOpenPopupStartGameButtonClicked);
            _openPopupResetProgressButton.onClick.AddListener(OnOpenPopupResetProgressButtonClicked);
            _openStatsUpgradeButton.onClick.AddListener(OnOpenStatsUpgradeButtonClicked);
        }

        private void OnDisable()
        {
            _openPopupStartGameButton.onClick.RemoveListener(OnOpenPopupStartGameButtonClicked);
            _openPopupResetProgressButton.onClick.RemoveListener(OnOpenPopupResetProgressButtonClicked);
            _openStatsUpgradeButton.onClick.RemoveListener(OnOpenStatsUpgradeButtonClicked);
        }

        private void OnOpenPopupStartGameButtonClicked() => OpenPopupStartGameButtonClicked?.Invoke();
        private void OnOpenPopupResetProgressButtonClicked() => OpenPopupResetProgressClicked?.Invoke();
        private void OnOpenStatsUpgradeButtonClicked() => OpenStatsUpgradeButtonClicked?.Invoke();
    }
}

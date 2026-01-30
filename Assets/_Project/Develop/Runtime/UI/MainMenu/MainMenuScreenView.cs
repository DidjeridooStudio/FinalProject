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

        [field: SerializeField] public IconTextListView WalletView {  get; private set; }
        [field: SerializeField] public ProgressionView ProgressionView {  get; private set; }

        [SerializeField] private Button _openPopupStartGameButton;
        [SerializeField] private Button _openPopupResetProgressButton;

        private void OnEnable()
        {
            _openPopupStartGameButton.onClick.AddListener(OnOpenPopupStartGameButtonClicked);
            _openPopupResetProgressButton.onClick.AddListener(OnOpenPopupResetProgressButtonClicked);
        }

        private void OnDisable()
        {
            _openPopupStartGameButton.onClick.RemoveListener(OnOpenPopupStartGameButtonClicked);
            _openPopupResetProgressButton.onClick.RemoveListener(OnOpenPopupResetProgressButtonClicked);
        }

        private void OnOpenPopupStartGameButtonClicked() => OpenPopupStartGameButtonClicked?.Invoke();
        private void OnOpenPopupResetProgressButtonClicked() => OpenPopupResetProgressClicked?.Invoke();
    }
}

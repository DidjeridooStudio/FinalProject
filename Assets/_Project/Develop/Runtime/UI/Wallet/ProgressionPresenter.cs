using Assets._Project.Develop.Runtime.Meta.Features;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Wallet
{
    public class ProgressionPresenter : IPresenter
    {
        private readonly ProgressionService _progressionService;
        private readonly ProgressionView _view;

        private List<IDisposable> _disposables = new List<IDisposable>();

        public ProgressionPresenter(ProgressionService progressionService, ProgressionView view)
        {
            _progressionService = progressionService;
            _view = view;
        }

        #region Interface

        public void Initialize()
        {
            UpdateValue();

            _disposables.Add(_progressionService.WinningsQuantity.Subcribe(OnWinningsQuantityChanged));
            _disposables.Add(_progressionService.LossesQuantity.Subcribe(OnLossesQuantityChanged));
        }

        public void Dispose()
        {
            foreach (IDisposable disposable in _disposables)
                disposable.Dispose();
        }

        #endregion

        private void UpdateValue()
        {
            _view.SetWinningsText(_progressionService.WinningsQuantity.Value.ToString());
            _view.SetLossesText(_progressionService.LossesQuantity.Value.ToString());
        }

        private void OnWinningsQuantityChanged(int oldValue, int newValue) => _view.SetWinningsText(newValue.ToString());

        private void OnLossesQuantityChanged(int oldValue, int newValue) => _view.SetLossesText(newValue.ToString());
    }
}

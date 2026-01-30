using Assets._Project.Develop.Runtime.Configs.Meta.Wallet;
using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using Assets._Project.Develop.Runtime.Utilies.Reactive;
using System;

namespace Assets._Project.Develop.Runtime.UI.Wallet
{
    public class CurrencyPresenter : IPresenter
    {
        private readonly CurrencyTypes _currencyType;
        private readonly IReadOnlyVariable<int> _currency;
        private readonly CurrencyIconsConfig _currencyIconsConfig;

        private readonly IconTextView _view;

        private IDisposable _disposable;

        public CurrencyPresenter(CurrencyTypes currencyType, IReadOnlyVariable<int> currency, CurrencyIconsConfig currencyIconsConfig, IconTextView iconTextView)
        {
            _currencyType = currencyType;
            _currency = currency;
            _currencyIconsConfig = currencyIconsConfig;
            _view = iconTextView;
        }

        public IconTextView View => _view;

        #region Interface

        public void Initialize()
        {
            UpdateValue(_currency.Value);
            _view.SetIcon(_currencyIconsConfig.GetSpriteFor(_currencyType));

            _disposable = _currency.Subcribe(OnCurrencyChanged);
        }

        public void Dispose()
        {
            _disposable.Dispose();
        }

        #endregion

        private void UpdateValue(int value) => _view.SetText(value.ToString());

        private void OnCurrencyChanged(int oldValue, int newValue) => UpdateValue(newValue);
    }
}

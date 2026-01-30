using Assets._Project.Develop.Runtime.Meta.Features.Wallet;
using Assets._Project.Develop.Runtime.UI.CommonViews;
using Assets._Project.Develop.Runtime.UI.Core;
using System.Collections.Generic;

namespace Assets._Project.Develop.Runtime.UI.Wallet
{
    public class WalletPresenter : IPresenter
    {
        private readonly WalletService _walletService;
        private readonly ProjectPresentersFactory _presentersFactory;
        private readonly ViewsFactory _viewsFactory;
        private readonly IconTextListView _view;

        private readonly List<CurrencyPresenter> _currencyPresenters = new List<CurrencyPresenter>();

        public WalletPresenter(WalletService walletService, ProjectPresentersFactory presentersFactory, ViewsFactory viewsFactory, IconTextListView iconTextListView)
        {
            _walletService = walletService;
            _presentersFactory = presentersFactory;
            _viewsFactory = viewsFactory;
            _view = iconTextListView;
        }

        #region Interface

        public void Initialize()
        {
            foreach (CurrencyTypes currencyTypes in _walletService.AvailableCurrencies)
            {
                IconTextView currencyView = _viewsFactory.Create<IconTextView>(ViewsIDs.CurrencyView);
                _view.Add(currencyView);

                CurrencyPresenter currencyPresenter = _presentersFactory.CreateCurrencyPresenter(
                    currencyTypes,
                    _walletService.GetCurrency(currencyTypes),
                    currencyView);

                currencyPresenter.Initialize();

                _currencyPresenters.Add(currencyPresenter);
            }
        }

        public void Dispose()
        {
            foreach (CurrencyPresenter presenter in _currencyPresenters)
            {
                _view.Remove(presenter.View);
                _viewsFactory.Release(presenter.View);
                presenter.Dispose();
            }

            _currencyPresenters.Clear();
        }

        #endregion
    }
}

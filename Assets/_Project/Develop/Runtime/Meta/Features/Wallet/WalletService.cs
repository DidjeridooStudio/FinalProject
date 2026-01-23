using System;
using System.Collections.Generic;
using System.Linq;

public class WalletService : IDataReader<PlayerData>, IDataWriter<PlayerData>
{
    private readonly Dictionary<CurrencyTypes, ReactiveVariable<int>> _currencies;

    public WalletService(Dictionary<CurrencyTypes, ReactiveVariable<int>> currencies, PlayerDataProvider playerDataProvider)
    {
        _currencies = new Dictionary<CurrencyTypes, ReactiveVariable<int>>(currencies);

        playerDataProvider.RegisterDataReader(this);
        playerDataProvider.RegisterDataWriters(this);
    }

    public List<CurrencyTypes> AvailableCurrencies => _currencies.Keys.ToList();

    public IReadOnlyVariable<int> GetCurrency(CurrencyTypes currencyType) => _currencies[currencyType];

    public bool EnoughCurrency(CurrencyTypes currencyType, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        return _currencies[currencyType].Value >= amount;
    }

    public void AddCurrency(CurrencyTypes currencyType, int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _currencies[currencyType].Value += amount;
    }

    public void SpendCurrency(CurrencyTypes currencyType, int amount)
    {
        if (EnoughCurrency(currencyType, amount) == false)
            throw new InvalidOperationException("Not enough " + currencyType.ToString());

        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        _currencies[currencyType].Value -= amount;
    }

    #region Interface

    public void ReadFrom(PlayerData data)
    {
        foreach (KeyValuePair<CurrencyTypes, int> currency in data.WalletData)
        {
            if (_currencies.ContainsKey(currency.Key))
                _currencies[currency.Key].Value = currency.Value;
            else
                _currencies.Add(currency.Key, new ReactiveVariable<int>(currency.Value));
        }
    }

    public void WriteTo(PlayerData data)
    {
        foreach (KeyValuePair<CurrencyTypes, ReactiveVariable<int>> currency in _currencies)
        {
            if (data.WalletData.ContainsKey(currency.Key))
                data.WalletData[currency.Key] = currency.Value.Value;
            else
                data.WalletData.Add(currency.Key, currency.Value.Value);
        }
    }

    #endregion
}

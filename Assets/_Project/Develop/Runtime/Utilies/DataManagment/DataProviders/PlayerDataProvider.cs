using System;
using System.Collections.Generic;

public class PlayerDataProvider : DataProvider<PlayerData>
{
    private readonly ConfigsProviderService _configProviderService;

    public PlayerDataProvider(ISaveLoadService saveLoadService, ConfigsProviderService configProviderService) : base(saveLoadService)
    {
        _configProviderService = configProviderService;
    }

    protected override PlayerData GetOriginData()
    {
        return new PlayerData()
        {
            WalletData = InitWalletData(),
        };
    }

    private Dictionary<CurrencyTypes, int> InitWalletData()
    {
        Dictionary<CurrencyTypes, int> walletData = new Dictionary<CurrencyTypes, int>();

        StartWalletConfig startWalletConfig = _configProviderService.GetConfig<StartWalletConfig>();

        foreach (CurrencyTypes currencyType in Enum.GetValues(typeof(CurrencyTypes)))
            walletData.Add(currencyType, startWalletConfig.GetValueFor(currencyType));

        return walletData;
    }
}

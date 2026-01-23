using System.Collections.Generic;

public class PlayerData : ISaveData
{
    public Dictionary<CurrencyTypes, int> WalletData;

    public int WinningsQuantity;
    public int LossesQuantity;
}

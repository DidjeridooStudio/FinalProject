
public class ProgressionService : IDataReader<PlayerData>, IDataWriter<PlayerData>
{
    private ReactiveVariable<int> _winningsQuantity = new ReactiveVariable<int>();
    private ReactiveVariable<int> _lossesQuantity = new ReactiveVariable<int>();

    public ProgressionService(PlayerDataProvider playerDataProvider)
    {
        playerDataProvider.RegisterDataReader(this);
        playerDataProvider.RegisterDataWriters(this);
    }

    public int WinningsQuantity => _winningsQuantity.Value;
    public int LossesQuantity => _lossesQuantity.Value;

    public void IncreaseWinnings() => _winningsQuantity.Value++;
    public void IncreaseLosses() => _lossesQuantity.Value++;

    public void Reset()
    {
        _winningsQuantity.Value = 0;
        _lossesQuantity.Value = 0;
    }

    #region Interface

    public void ReadFrom(PlayerData data)
    {
        _winningsQuantity.Value = data.WinningsQuantity;
        _lossesQuantity.Value = data.LossesQuantity;
    }

    public void WriteTo(PlayerData data)
    {
        data.WinningsQuantity = _winningsQuantity.Value;
        data.LossesQuantity = _lossesQuantity.Value;
    }

    #endregion
}

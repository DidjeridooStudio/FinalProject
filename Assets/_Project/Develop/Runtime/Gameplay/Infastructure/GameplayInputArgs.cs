
public class GameplayInputArgs : IInputSceneArgs
{
    public GameplayInputArgs(string symbolSet, int symbolsQuanity, int moneyBet)
    {
        SymbolSet = symbolSet;
        SymbolsQuanity = symbolsQuanity;
        MoneyBet = moneyBet;
    }

    public string SymbolSet { get; }
    public int SymbolsQuanity { get; }
    public int MoneyBet { get; }
}

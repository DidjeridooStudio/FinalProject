
public class GameplayInputArgs : IInputSceneArgs
{
    public GameplayInputArgs(string symbolSet, int symbolsQuanity)
    {
        SymbolSet = symbolSet;
        SymbolsQuanity = symbolsQuanity;
    }

    public string SymbolSet { get; }
    public int SymbolsQuanity { get; }
}

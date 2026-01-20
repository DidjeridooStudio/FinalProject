
public class GameplayInputArgs : IInputSceneArgs
{
    public GameplayInputArgs(string symbolSet)
    {
        SymbolSet = symbolSet;
    }

    public string SymbolSet { get; }
}

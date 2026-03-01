using Assets._Project.Develop.Runtime.Configs.Gameplay.Levels;
using Assets._Project.Develop.Runtime.Utilies.ScenesManagment;

namespace Assets._Project.Develop.Runtime.Gameplay.Infastructure
{
    public class GameplayInputArgs : IInputSceneArgs
    {
        public GameplayInputArgs(string symbolSet, int symbolsQuanity, int moneyBet, GameLevelConfig levelConfig)
        {
            SymbolSet = symbolSet;
            SymbolsQuanity = symbolsQuanity;
            MoneyBet = moneyBet;
            LevelConfig = levelConfig;
        }

        public string SymbolSet { get; }
        public int SymbolsQuanity { get; }
        public int MoneyBet { get; }
        public int LevelNumber { get; }
        public GameLevelConfig LevelConfig { get; }
    }
}
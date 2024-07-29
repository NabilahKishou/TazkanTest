namespace NabilahKishou.TazkanTest
{
    public readonly ref struct EventStringDirectory
    {
        //Un-param
        public const string StartGame = "startgame";
        public const string GameOver = "gameover";
        public const string RestartGame = "restartgame";
        public const string SequenceMatch = "sequencematch";
        public const string WaveSpawned = "wavespawned";
        public const string ClearBasket = "clearbasket";

        //param
        public const string UpgradeStacker_Int = "upgradestacker_int";
        public const string CheckSequence_ArrInt = "checksequence_arrint";
    }
}
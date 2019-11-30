namespace ServerApp.GameState
{
    public static class GameStateFactory
    {
        public static GameStateClass GenerateNewGameState()
        {
            ILayerGenerator layerGenerator = new HardCodedLayerGenerator();
            IPlayer player = new Player(new Position(0, 0), new Stats(50, 10, 10), "PlayerBBoy123", 15);

            return new GameStateClass(new Map(layerGenerator, 5, player));
        }
    }
}
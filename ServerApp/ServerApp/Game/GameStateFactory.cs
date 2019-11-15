namespace ServerApp.Game
{
    public static class GameStateFactory
    {
        public static GameState GenerateNewGameState()
        {
            ILayerGenerator layerGenerator = new HardCodedLayerGenerator();
            Player player = new Player(new Position(0, 0), new Stats(50, 10, 10), "PlayerBBoy123", 15);

            return new GameState(new Map(layerGenerator, 5, player));
        }
    }
}
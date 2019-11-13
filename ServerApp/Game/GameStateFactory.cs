namespace ServerApp.Game
{
    public static class GameStateFactory
    {
        public static GameState GenerateNewGameState()
        {
            ILayerGenerator layerGenerator = new HardCodedLayerGenerator();
            Player player = new Player(new Position(0, 0), new Stats(50, 10, 10), "PlayerBBoy123", 0);

            return new GameState(player, new Map(layerGenerator, 5));
        }
    }
}
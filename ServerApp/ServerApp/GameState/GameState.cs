namespace ServerApp.GameState
{
    public class GameStateClass : IGameState
    {
        public IPlayer Player => Map.GetPlayer();
        public IMap Map { get; private set; }

        public GameStateClass(IMap map)
        {
            this.Map = map;
        }
    }
}

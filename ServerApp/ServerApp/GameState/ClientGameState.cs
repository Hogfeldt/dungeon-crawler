namespace ServerApp.GameState
{
    public class ClientGameState
    {
        public Player Player = null;
        public ITile[,] Tiles = null;
        public ICharacter[,] Characters = null;
        public IPosition InitialPlayerPosition = null;
        public IPosition ExitPosition = null;
        public IInteractiveObject[,] InteractiveObjects = null;

        public ClientGameState(IGameState gameState)
        { 
            Player = gameState.Player;
            Tiles = gameState.Map.GetCurrentLayer().Tiles;
            Characters = gameState.Map.GetCurrentLayer().Characters;
            InitialPlayerPosition = gameState.Map.GetCurrentLayer().InitialPlayerPosition;
            ExitPosition = gameState.Map.GetCurrentLayer().ExitPosition;
            InteractiveObjects = gameState.Map.GetCurrentLayer().InteractiveObjects;
        }
    }
}

using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ServerApp.Game
{
    public class ClientGameState
    {
        public Player Player = null;
        public ITile[,] Tiles = null;
        public Character[,] Characters = null;

        public ClientGameState(GameState gameState)
        {
            Player = gameState.Player;
            Tiles = gameState.Map.GetCurrentLayer().Tiles;
            Characters = gameState.Map.GetCurrentLayer().Characters;
        }
    }
}
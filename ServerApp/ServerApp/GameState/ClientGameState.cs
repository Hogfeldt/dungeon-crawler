using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ServerApp.GameState
{
    public class ClientGameState
    {
        public Player Player = null;
        public ITile[,] Tiles = null;
        public ICharacter[,] Characters = null;

        public ClientGameState(IGameState gameState)
        {
            Player = gameState.Player;
            Tiles = gameState.Map.GetCurrentLayer().Tiles;
            Characters = gameState.Map.GetCurrentLayer().Characters;
        }
    }
}
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ServerApp.GameState
{
    public class ClientGameState
    {
        public Player Player = null;
        public ITile[,] Tiles = null;
        public Character[,] NPCs = null;

        public ClientGameState(GameState gameState)
        {
            Player = (Player) gameState.Player;
            Tiles = gameState.Map.GetLayer(Player.Layer).Tiles;
            NPCs = gameState.Map.GetLayer(Player.Layer).NPCs;
        }
    }
}
using System.Security.Cryptography.X509Certificates;
using ServerApp.GameState;

namespace ServerApp.GameState
{
    public class HardCodedLayer: ILayer
    {
        public Character[,] NPCs;
        public ITile[,] Tiles;

        public HardCodedLayer()
        {
            int width = 10;
            int height = 10;
            NPCs = new Character[width, height];
            Tiles = new ITile[width,height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Tiles[x, y] = new Tile(false);
                    NPCs[x, y] = null;
                }
            }

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                }
            }
        }
    }
}
using System.Security.Cryptography.X509Certificates;
using ServerApp.GameState;

namespace ServerApp.GameState
{
    public class HardCodedLayerGenerator: ILayerGenerator
    {

        public ILayer GenerateLayer()
        {
            uint width = 10;
            uint height = 10;


            Character[,] npcs = new Character[width,height];
            ITile[,] tiles = new ITile[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(false);
                    npcs[x, y] = null;
                }
            }

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    if (x <= 3 && y <= 1)
                    {
                        tiles[x, y].Walkable = true;
                    }

                    if (x == 3 && y <= 4)
                    {
                        tiles[x, y].Walkable = true;
                    }

                    if (x >= 3 && x <= 6 && y == 4)
                    {
                        tiles[x, y].Walkable = true;
                    }

                    if (x >= 7 && x <= 9 && y >= 4 && y <= 6)
                    {
                        tiles[x, y].Walkable = true;
                    }
                }
            }

            npcs[3, 1] = new HostileNPC();
            npcs[3, 4] = new HostileNPC();
            npcs[8, 4] = new HostileNPC();

            return new Layer(tiles, npcs);
        }
    }


}
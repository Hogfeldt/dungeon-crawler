using System.Security.Cryptography.X509Certificates;
using ServerApp.Game;

namespace ServerApp.Game
{
    public class HardCodedLayerGenerator: ILayerGenerator
    {

        public ILayer GenerateLayer(int layerNumber)
        {
            uint width = 10;
            uint height = 10;


            NPC[,] npcs = new NPC[width,height];
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

            npcs[3, 1] = new HostileNPC(new Position(3,1), new Stats(speed: 3), new RandomMovementStrategy(), "Hurtigfar", 30);
            npcs[3, 4] = new HostileNPC(new Position(3, 4), new Stats(speed: 2), new RandomMovementStrategy(), "Mellemhurtigfar", 20);
            npcs[8, 4] = new HostileNPC(new Position(8, 4), new Stats(speed: 1), new RandomMovementStrategy(), "Langsomfar", 10);

            tiles[layerNumber,9].Walkable = true;

            return new Layer(tiles, npcs);
        }
    }


}
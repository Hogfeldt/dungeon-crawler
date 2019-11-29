using System;

namespace ServerApp.GameState
{
    public class HardCodedLayerGenerator: ILayerGenerator
    {
        public ILayer GenerateLayer(int layerNumber)
        {
            uint width = 10;
            uint height = 10;


            Character[,] characters = new Character[width,height];
            ITile[,] tiles = new ITile[width, height];
            IInteractiveObject[,] objects = new IInteractiveObject[width, height];
            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0) {
                objects[3,0] = new Chest();
            } else {
                objects[3,0] = new ChestMimic();
            }

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(false);
                    characters[x, y] = null;
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

            characters[3, 1] = new HostileNPC(new Position(3,1), new Stats(1, 1, 1), new StandStillMovementStrategy(), "Hurtigfar", 30);
            characters[3, 4] = new HostileNPC(new Position(3, 4), new Stats(10, 2, 2), new StandStillMovementStrategy(), "Mellemhurtigfar", 20);
            characters[8, 4] = new HostileNPC(new Position(8, 4), new Stats(10, 10, 10), new RandomMovementStrategy(), "Langsomfar", 10);

            tiles[layerNumber,9].Walkable = true;

            

            if (layerNumber == 2)
            {
                objects[2, 0] = new Stairs(false);
                objects[8, 6] = new Stairs(true);
                return new Layer(tiles, characters, new Position(2,0), new Position(8,6), objects);
            }

            if (layerNumber == 3)
            {
                objects[9, 4] = new Stairs(false);
                objects[0, 1] = new Stairs(true);
                characters[1, 1] = new HostileNPC(new Position(1,1), new Stats(35, 5, 4), new StandStillMovementStrategy(), "TankyFar", 200);

                return new Layer(tiles, characters, new Position(9,4),new Position(0,1), objects);
            }

            objects[0, 0] = new Stairs(false);
            objects[8, 5] = new Stairs(true);
            return new Layer(tiles, characters, new Position(0,0), new Position(8,5), objects);
        }
    }


}

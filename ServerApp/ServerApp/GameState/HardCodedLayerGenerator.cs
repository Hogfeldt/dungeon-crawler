using System;

namespace ServerApp.GameState
{
    public class HardCodedLayerGenerator: ILayerGenerator
    {
        public Layer GenerateLayer(int layerNumber)
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

            Layer layer;
            
            switch(layerNumber) {
                case 0:
                    layer = new TopLayer(tiles, characters, new Position(8,5), new Position(0,0), objects);
                    break;
                case 2: 
                    layer = new MiddelLayer(tiles, characters, new Position(2,0), new Position(8,6), objects);  
                    break;
                case 3:              
                    characters[1, 1] = new HostileNPC(new Position(1,1), new Stats(35, 5, 4), new StandStillMovementStrategy(), "TankyFar", 200);
                    layer = new MiddelLayer(tiles, characters, new Position(9,4),new Position(0,1), objects);
                    break;
                case 4:
                    layer = new BottomLayer(tiles, characters, new Position(8,5), objects);
                    break;
                default:
                    layer = new MiddelLayer(tiles, characters, new Position(0,0), new Position(8,5), objects);
                    break;

            }
            return layer;
        }
    }


}

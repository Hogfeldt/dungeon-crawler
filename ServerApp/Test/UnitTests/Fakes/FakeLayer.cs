using System;
using System.Collections.Generic;
using System.Text;
using ServerApp.GameState;
using ServerApp.TurnExec;

namespace Test.UnitTests.Fakes
{
    public class FakeLayer : ILayerGenerator
    {
        public Layer GenerateLayer(int layerNumber)
        {
            uint width = 10;
            uint height = 10;

            ICharacter[,] characters = new ICharacter[width, height];
            ITile[,] tiles = new ITile[width, height];
            IInteractiveObject[,] objects = new IInteractiveObject[width, height];

            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    tiles[x, y] = new Tile(true);
                }
            }

            characters[3, 1] = new HostileNPC(new Position(3, 1), new Stats(1, 1, 1), new StandStillMovementStrategy(), "Hurtigfar", 30);
            characters[3, 4] = new HostileNPC(new Position(3, 4), new Stats(10, 2, 2), new StandStillMovementStrategy(), "Mellemhurtigfar", 20);
            characters[8, 4] = new HostileNPC(new Position(8, 4), new Stats(10, 10, 10), new RandomMovementStrategy(), "Langsomfar", 10);

            tiles[layerNumber, 9].Walkable = true;

            Layer layer;

            switch (layerNumber)
            {
                case 0:
                    layer = new TopLayer(tiles, characters, new Position(0, 0), new Position(5, 5), objects);
                    break;
                case 1:
                    layer = new MiddelLayer(tiles, characters, new Position(0, 0), new Position(5, 5), objects);
                    break;
                default:
                    layer = new TopLayer(tiles, characters, new Position(0, 0), new Position(5, 5), objects);
                    break;

            }
            return layer;
        }
    }
}

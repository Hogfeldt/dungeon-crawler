namespace ServerApp.GameState
{
    public class DefaultLayerGenerator : ILayerGenerator
    {
        public Layer GenerateLayer(int layerNumber)
        {
            uint width = 10;
            uint height = 10;


            NPC[,] npcs = new NPC[width, height];
            ITile[,] tiles = new ITile[width, height];
            IInteractiveObject[,] objects = new IInteractiveObject[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(false);
                    npcs[x, y] = null;
                }
            }

            return new MiddelLayer(tiles, npcs, new Position(0,0), new Position(9,9), objects);
        }
    }
}
namespace ServerApp.GameState
{
    public class DefaultLayerGenerator : ILayerGenerator
    {
        public ILayer GenerateLayer(int layerNumber)
        {
            uint width = 10;
            uint height = 10;


            NPC[,] npcs = new NPC[width, height];
            ITile[,] tiles = new ITile[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(false);
                    npcs[x, y] = null;
                }
            }

            return new Layer(tiles, npcs, new Position(0,0));
        }
    }
}
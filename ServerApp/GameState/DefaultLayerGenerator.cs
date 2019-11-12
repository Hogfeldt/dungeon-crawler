namespace ServerApp.GameState
{
    public class DefaultLayerGenerator : ILayerGenerator
    {
        public ILayer GenerateLayer()
        {
            uint width = 10;
            uint height = 10;


            Character[,] npcs = new Character[width, height];
            ITile[,] tiles = new ITile[width, height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    tiles[x, y] = new Tile(false);
                    npcs[x, y] = null;
                }
            }

            return new Layer(tiles, npcs);
        }
    }
}
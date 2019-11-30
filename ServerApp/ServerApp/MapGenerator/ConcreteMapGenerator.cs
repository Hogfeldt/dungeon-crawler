using System;

namespace ServerApp.MapGenerator
{
    public class ConcreteMapGenerator
    {
        public int Dimensions { get; private set; }
        public int MaxTunnels { get; private set; }
        public int MaxTunnelLength { get; private set; }

        public ConcreteMapGenerator(int dimensions, int maxTunnels, int maxTunnelLength)
        {
            this.Dimensions = dimensions;
            this.MaxTunnels = maxTunnels;
            this.MaxTunnelLength = maxTunnelLength;
        }

        public bool[,] createMap()
        {
            bool[,] map = new bool[Dimensions, Dimensions];

            for (var i = 0; i < Dimensions; i++)
            {
                for (var j = 0; j < Dimensions; j++)
                {
                    map[i, j] = false;
                }
            }

            Random rand = new Random();
            int currentRow = (int) Math.Floor(rand.NextDouble() * Dimensions);
            int currentColumn = (int) Math.Floor(rand.NextDouble() * Dimensions);

            int[,] directions = new int[4,2] {{-1,0}, {1,0}, {0,-1}, {0,1}};

            int[] lastDirection = new int[2] { 0, 0 };
            int[] randomDirection = new int[2] { 0, 0 };


            return map;
        }

    }
}
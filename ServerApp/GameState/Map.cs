using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.CodeAnalysis.Host.Mef;

namespace ServerApp.GameState
{
    public class Map
    {
        public uint LayerCount { private set; get; }
        private List<Layer> layers_ = new List<Layer>();

        public Map(int LayerCount)
        {
            for (int i = 0; i < LayerCount; i++)
            {
                layers_.Add(new Layer());
            }
        }
    }
}
using System.Collections.Generic;

namespace ServerApp.GameState
{
    public class HardCodedMap: IMap
    {
        public List<ILayer> = new List<HardCodedLayer>
        public HardCodedMap()
        {
            for (int i = 0; i < 5; i++)
            {
                Layers.Add(new Layer(10, 10));
            }
        }
    }
}
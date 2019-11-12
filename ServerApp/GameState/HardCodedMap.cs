using System.Collections.Generic;

namespace ServerApp.GameState
{
    public class HardCodedMap: IMap
    {
        public List<ILayer> Layers = new List<ILayer>();
        public HardCodedMap()
        {
            HardCodedLayerGenerator layerGenerator = new HardCodedLayerGenerator();
            for (int i = 0; i < 5; i++)
            {
                Layers.Add(layerGenerator.GenerateLayer());
            }
        }

        public ILayer GetLayer(int layer)
        {
            return Layers[layer];
        }
    }
}
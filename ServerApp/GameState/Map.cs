using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.CodeAnalysis.Host.Mef;

namespace ServerApp.GameState
{
    public class Map: IMap
    {
        public List<ILayer> layers_ = new List<ILayer>();

        public Map(uint layerCount)
        {
            for (int i = 0; i < layerCount; i++)
            {
                layers_.Add(new Layer(10, 10));
            }
        }

        public ILayer GetLayer(int layer)
        {
            if (layers_.Count - 1 > layer && layer >= 0)
            {
                return layers_[layer];
            } else { 
                throw new ArgumentOutOfRangeException(nameof(layer),"Input larger than amount of layers or less than 0");
            }
        }
    }
}
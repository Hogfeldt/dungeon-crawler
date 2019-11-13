using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.CodeAnalysis.Host.Mef;

namespace ServerApp.Game
{
    public class Map: IMap
    {
        public List<ILayer> Layers { get; private set; } = new List<ILayer>();

        public Map(ILayerGenerator layerGenerator, int layerCount)
        {
            for (int i = 0; i < layerCount; i++)
            {
                Layers.Add(layerGenerator.GenerateLayer(i));
            }
        }

        public ILayer GetLayer(int layer)
        {
            if (Layers.Count - 1 > layer && layer >= 0)
            {
                return Layers[layer];
            } else { 
                throw new ArgumentOutOfRangeException(nameof(layer),"Input larger than amount of layers or less than 0");
            }
        }
    }
}
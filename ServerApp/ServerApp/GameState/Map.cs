using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Map: IMap
    {
        public int CurrentLayerNumber { get; private set; } = 0;
        public List<ILayer> Layers { get; private set; } = new List<ILayer>();

        public Map(ILayerGenerator layerGenerator, int layerCount, IPlayer player)
        {
            GenerateLayers(layerGenerator, layerCount);
            SpawnPlayer(player, (TopLayer) Layers[0]);
        }
        
        [JsonConstructor]
        public Map(List<ILayer> layers, int currentLayerNumber)
        {
            Layers = layers;
            CurrentLayerNumber = currentLayerNumber;
        }

        private void GenerateLayers(ILayerGenerator layerGenerator, int layerCount)
        {
            for (int i = 0; i < layerCount; i++)
            {
                Layers.Add(layerGenerator.GenerateLayer(i));
            }
        }

        private void SpawnPlayer(IPlayer player, TopLayer layer)
        {
            player.Position = layer.spawnPosition;
            layer.AddCharacter(player);
        }

        private ILayer GetLayer(int layer)
        {
            if (Layers.Count > layer && layer >= 0)
            {
                return Layers[layer];
            } else
            {
                return null;
            }
        }

        public ILayer getLayerBelowOrNull() 
        {
            return GetLayer(CurrentLayerNumber + 1);
        }

        public ILayer getLayerAboveOrNull()
        {
            return GetLayer(CurrentLayerNumber - 1);
        }

        public ILayer GetCurrentLayer()
        {
            return Layers[CurrentLayerNumber];
        }

        public IPlayer GetPlayer()
        {
            foreach (var character in GetLayer(CurrentLayerNumber).Characters)
            {
                if (character != null && character.GetType() == typeof(ConcretePlayer))
                {
                    return (ConcretePlayer) character;
                }
            }
            return null;
        }
    }
}

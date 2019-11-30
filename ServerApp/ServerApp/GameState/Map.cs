using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Map: IMap
    {
        public int CurrentLayerNumber { get; private set; } = 0;
        public List<Layer> Layers { get; private set; } = new List<Layer>();

        public Map(ILayerGenerator layerGenerator, int layerCount, Player player)
        {
            GenerateLayers(layerGenerator, layerCount);
            SpawnPlayer(player);
        }
        
        [JsonConstructor]
        public Map(List<Layer> layers, int currentLayerNumber)
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

        private void SpawnPlayer(Player player)
        {
            player.Position = GetLayer(CurrentLayerNumber).getEnteringPositionOrNull();
            GetLayer(CurrentLayerNumber).AddCharacter(player);
        }

        private Layer GetLayer(int layer)
        {
            if (Layers.Count > layer && layer >= 0)
            {
                return Layers[layer];
            } else
            {
                return null;
            }
        }

        public Layer getLayerBelowOrNull() 
        {
            return GetLayer(CurrentLayerNumber + 1);
        }

        public Layer getLayerAboveOrNull()
        {
            return GetLayer(CurrentLayerNumber - 1);
        }

        public Layer GetCurrentLayer()
        {
            return Layers[CurrentLayerNumber];
        }

        public Player GetPlayer()
        {
            foreach (var character in GetLayer(CurrentLayerNumber).Characters)
            {
                if (character != null && character.GetType() == typeof(ConcretePlayer))
                {
                    return (Player) character;
                }
            }
            return null;
        }

        public bool MovePlayerToNewLayer(int layerNumber, bool descending)
        {
            Player player = GetPlayer();
            Position previousPosition = new Position(player.Position);
            Layer layer = GetLayer(layerNumber);
            if (layer == null)
                return false;
            if (descending)
            {
                player.Position = layer.getEnteringPositionOrNull();
            }
            else
            {
                // TODO: Handle null 
                player.Position = layer.getEnteringPositionOrNull();
            }
            layer.AddCharacter(player);
            GetLayer(CurrentLayerNumber).RemoveCharacterFromPosition(player.Position);
            CurrentLayerNumber = layerNumber;
            return true;
        }
    }
}

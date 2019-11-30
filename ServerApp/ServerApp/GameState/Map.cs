using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Map: IMap
    {
        public int CurrentLayerNumber { get; private set; } = 0;
        public List<ILayer> Layers { get; private set; } = new List<ILayer>();

        public Map(ILayerGenerator layerGenerator, int layerCount, Player player)
        {
            GenerateLayers(layerGenerator, layerCount);
            SpawnPlayer(player);
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

        private void SpawnPlayer(Player player)
        {
            player.Position = GetLayer(CurrentLayerNumber).InitialPlayerPosition;
            GetLayer(CurrentLayerNumber).AddCharacter(player);
        }

        public ILayer GetLayer(int layer)
        {
            if (Layers.Count > layer && layer >= 0)
            {
                return Layers[layer];
            } else
            {
                return null;
            }
        }

        public ILayer GetCurrentLayer()
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
            ILayer layer = GetLayer(layerNumber);
            if (layer == null)
                return false;
            if (descending)
            {
                player.Position = layer.InitialPlayerPosition;
            }
            else
            {
                player.Position = layer.ExitPosition;
            }
            layer.AddCharacter(player);
            GetLayer(CurrentLayerNumber).RemoveCharacterFromPosition(player.Position);
            CurrentLayerNumber = layerNumber;
            return true;
        }
    }
}

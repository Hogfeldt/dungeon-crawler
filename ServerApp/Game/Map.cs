using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Host.Mef;
using Newtonsoft.Json;

namespace ServerApp.Game
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
            if (Layers.Count - 1 > layer && layer >= 0)
            {
                return Layers[layer];
            } else { 
                throw new ArgumentOutOfRangeException(nameof(layer),"Input larger than amount of layers or less than 0");
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
                if (character != null && character.GetType() == typeof(Player))
                {
                    return (Player) character;
                }
            }
            return null;
        }

        public void MovePlayerToNewLayer(int layer)
        {
            Player player = GetPlayer();
            Position previousPosition = new Position(player.Position);
            player.Position = GetLayer(layer).InitialPlayerPosition;
            GetLayer(layer).AddCharacter(player);
            GetLayer(CurrentLayerNumber).RemoveCharacterFromPosition(player.Position);
            CurrentLayerNumber = layer;
        }
    }
}
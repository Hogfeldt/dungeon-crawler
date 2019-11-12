using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Layer: ILayer
    {
        public uint Height { private set; get; } = 10;
        public uint Width { private set; get; } = 10;
        public ITile[,] Tiles { private set; get; }
        public Character[,] NPCs { private set; get; }

        public Layer(uint width, uint height)
        {
            Width = width;
            Height = height;
            Tiles = new ITile[Width,Height];
            NPCs = new Character[Width,Height];

            for (var x = 0; x < Width; x++)
            {
                for (var y = 0; y < Height; y++)
                {
                    Tiles[x, y] = new Tile(false);
                    NPCs[x, y] = null;
                }
            }
        }

        [JsonConstructor]
        public Layer(ITile[,] tiles, Character[,] npcs)
        {
            Tiles = tiles;
            NPCs = npcs;
            Width = (uint) Tiles.GetLength(0);
            Height = (uint) Tiles.GetLength(1);
        }

        public void AddNPC(Character NPC)
        {
            NPCs[NPC.Position.X, NPC.Position.Y] = NPC;
        }

        public void RemoveNPCFromPosition(Position position)
        {
            NPCs[position.X, position.Y] = null;
        }

        public Character GetNPC(Position position)
        {
            return NPCs[position.X, position.Y];
        }

        public Character GetNPCFromPositionWithOffset(Position position, int xOff, int yOff)
        {
            return NPCs[position.X - xOff, position.Y - yOff];
        }

        public ITile GetTile(Position position)
        {
            return Tiles[position.X, position.Y];
        }

        public ITile GetTileWithOffset(Position position, int xOff, int yOff)
        {
            return Tiles[position.X - xOff, position.Y - yOff];
        }


    }
}

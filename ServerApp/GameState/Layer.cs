using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace ServerApp.GameState
{
    public class Layer: ILayer
    {
        public ITile[,] Tiles { private set; get; }
        public Character[,] NPCs { private set; get; }
        public Layer(uint width, uint height)
        {
            Tiles = new ITile[width,height];
            NPCs = new Character[width,height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    Tiles[x, y] = new Tile(true);
                    NPCs[x, y] = null;
                }
            }
        }

        public Layer(ITile[,] tiles, Character[,] npcs)
        {
            Tiles = tiles;
            NPCs = npcs;
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

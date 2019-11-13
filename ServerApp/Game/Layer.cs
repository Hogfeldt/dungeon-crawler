using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ServerApp.Game
{
    public class Layer: ILayer
    {
        public int Height { private set; get; } = 10;
        public int Width { private set; get; } = 10;
        public ITile[,] Tiles { private set; get; }
        public NPC[,] NPCs { private set; get; }

        [JsonConstructor]
        public Layer(ITile[,] tiles, NPC[,] npcs)
        {
            Tiles = tiles;
            NPCs = npcs;
            Width = Tiles.GetLength(0);
            Height = Tiles.GetLength(1);
        }

        public bool PositionIsValid(Position position)
        {
            if (position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height) return false;
            return true;
        }

        public void AddNPC(NPC npc)
        {
            if (!PositionIsValid(npc.Position))
            {
                return;
            }

            NPCs[npc.Position.X, npc.Position.Y] = npc;
        }

        public void RemoveNPCFromPosition(Position position)
        {
            if (!PositionIsValid(position))
            {
                return;
            }

            NPCs[position.X, position.Y] = null;
        }

        public NPC GetNPC(Position position)
        {
            if (!PositionIsValid(position))
            {
                return null;
            }
            return NPCs[position.X, position.Y];
        }

        public NPC GetNPCFromPositionWithOffset(Position position, int xOff, int yOff)
        {
            Position offsetPosition = new Position(position, xOff, yOff);

            return GetNPC(offsetPosition);
        }

        public ITile GetTile(Position position)
        {
            if (!PositionIsValid(position))
            {
                return new Tile(false);
            }
            return Tiles[position.X, position.Y];
        }

        public ITile GetTileWithOffset(Position position, int xOff, int yOff)
        {
            Position offSetPosition = new Position(position, xOff, yOff);

            return GetTile(offSetPosition);
        }


    }
}

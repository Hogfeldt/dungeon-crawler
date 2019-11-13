using System.Collections.Generic;

namespace ServerApp.Game
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        NPC[,] NPCs { get; } 

        void AddNPC(NPC NPC);
        void RemoveNPCFromPosition(Position position);
        NPC GetNPC(Position position);
        NPC GetNPCFromPositionWithOffset(Position position, int xOff, int yOff);
        ITile GetTile(Position position);
        ITile GetTileWithOffset(Position position, int xOff, int yOff);
    }
}
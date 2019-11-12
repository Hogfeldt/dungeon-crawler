using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        Character[,] NPCs { get; } 

        void AddNPC(Character NPC);
        void RemoveNPCFromPosition(Position position);
        Character GetNPC(Position position);
        Character GetNPCFromPositionWithOffset(Position position, int xOff, int yOff);
        ITile GetTile(Position position);
        ITile GetTileWithOffset(Position position, int xOff, int yOff);
    }
}
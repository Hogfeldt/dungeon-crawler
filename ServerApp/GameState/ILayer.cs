using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        Character[,] NPCs { get; }
        ITile GetTile(uint x, uint y);
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);
    }
}
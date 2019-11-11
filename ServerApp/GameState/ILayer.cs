using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        ITile GetTile(uint x, uint y);
        void AddCharacter(Character character);
        void RemoveCharacter(Character character);
    }
}
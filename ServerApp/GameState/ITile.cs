using System;

namespace ServerApp.GameState
{
    public interface ITile
    {
        bool Walkable { get; set; }
        bool Occupied { get; set; }
        Character Character { get; }

        Character ReplaceCharacter(Character character);
        void RemoveCharacter();
    }
}
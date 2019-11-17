using System.Collections.Generic;

namespace ServerApp.Game
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        Character[,] Characters { get; } 
        IPosition InitialPlayerPosition { get; }
        IPosition ExitPosition { get; }

        void AddCharacter(Character character);
        void RemoveCharacterFromPosition(IPosition position);
        bool MoveCharacter(IPosition oldPos, IPosition newPos);
        Character GetCharacter(IPosition position);
        Character GetCharacterFromPositionWithOffset(IPosition position, int xOff, int yOff);
        ITile GetTile(IPosition position);
        ITile GetTileWithOffset(IPosition position, int xOff, int yOff);
        List<Character> CharactersAsList();
    }
}
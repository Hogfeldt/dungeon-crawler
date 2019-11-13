using System.Collections.Generic;

namespace ServerApp.Game
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        Character[,] Characters { get; } 
        Position InitialPlayerPosition { get; }

        void AddCharacter(Character character);
        void RemoveCharacterFromPosition(Position position);
        bool MoveCharacter(Position oldPos, Position newPos);
        Character GetCharacter(Position position);
        Character GetCharacterFromPositionWithOffset(Position position, int xOff, int yOff);
        ITile GetTile(Position position);
        ITile GetTileWithOffset(Position position, int xOff, int yOff);
        List<Character> CharactersAsList();
    }
}
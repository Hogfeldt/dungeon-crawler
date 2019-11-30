using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        int Height { get; }
        int Width { get; }
        ITile[,] Tiles { get; }
        ICharacter[,] Characters { set; get; }
        IInteractiveObject[,] InteractiveObjects { get; }
        IPosition getExitingPositionOrNull();
        IPosition getEnteringPositionOrNull();
        void AddCharacter(ICharacter character);
        void RemoveCharacterFromPosition(IPosition position);
        ICharacter GetCharacter(IPosition position);
        ICharacter GetCharacterFromPositionWithOffset(IPosition position, int xOff, int yOff);
        ITile GetTile(IPosition position);
        ITile GetTileWithOffset(IPosition position, int xOff, int yOff);
        List<ICharacter> CharactersAsList();
    }
}
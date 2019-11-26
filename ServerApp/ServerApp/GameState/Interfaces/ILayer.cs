using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        ITile[,] Tiles { get; }
        ICharacter[,] Characters { get; set; }
        IPosition InitialPlayerPosition { get; }
        IPosition ExitPosition { get; }
        IInteractiveObject[,] InteractiveObjects {get;}

        void AddCharacter(ICharacter character);
        void RemoveCharacterFromPosition(IPosition position);
        bool MoveCharacter(IPosition oldPos, IPosition newPos);
        ICharacter GetCharacter(IPosition position);
        ICharacter GetCharacterFromPositionWithOffset(IPosition position, int xOff, int yOff);
        ITile GetTile(IPosition position);
        ITile GetTileWithOffset(IPosition position, int xOff, int yOff);
        List<ICharacter> CharactersAsList();
    }
}
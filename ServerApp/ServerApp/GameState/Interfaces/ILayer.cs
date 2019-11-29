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

        int Height { get; }
        int Width { get; }

        void AddCharacter(ICharacter character);
        void RemoveCharacterFromPosition(IPosition position);
        ICharacter GetCharacter(IPosition position);
        ICharacter GetCharacterFromPositionWithOffset(IPosition position, int xOff, int yOff);

        /*
        bool MoveCharacter(IPosition oldPos, IPosition newPos);
        */

        ITile GetTile(IPosition position);
        ITile GetTileWithOffset(IPosition position, int xOff, int yOff);
        List<ICharacter> CharactersAsList();
    }
}
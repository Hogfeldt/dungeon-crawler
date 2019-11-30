using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface ILayer
    {
        int Height { get; }
        int Width { get; }
        ITile[,] Tiles { get; }
        ICharacter[,] Characters { set; get; }

        IPosition EnteringPosition { set; get; }
        IPosition ExitingPosition { set; get; }

        IInteractiveObject[,] InteractiveObjects { get; }
        IPosition getExitingPositionOrNull();
        IPosition getEnteringPositionOrNull();
        void AddCharacter(ICharacter character);
        void RemoveCharacter(ICharacter character);
        ICharacter GetCharacter(IPosition position);
        ITile GetTile(IPosition position);
    }
}
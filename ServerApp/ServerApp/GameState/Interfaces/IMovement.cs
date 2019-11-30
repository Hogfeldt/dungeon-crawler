using System.Collections.Generic;

namespace ServerApp.GameState
{
    public interface IMovement
    {
        bool MoveCharacter(IPosition oldPos, IPosition newPos, Layer layer);
    }
}

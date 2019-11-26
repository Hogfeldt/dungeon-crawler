using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IMoveValidator
    {
        bool Validate(IPosition position, Character.Direction direction, ITile[,] tiles);
    }
}
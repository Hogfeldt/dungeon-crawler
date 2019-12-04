using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IMoveValidator
    {
        bool Validate(IPosition position, Direction direction, ITile[,] tiles);
    }
}
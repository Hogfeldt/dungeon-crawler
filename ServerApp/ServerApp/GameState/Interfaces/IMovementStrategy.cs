namespace ServerApp.GameState
{
    public interface IMovementStrategy
    {
        Direction GenerateMove();
    }
}
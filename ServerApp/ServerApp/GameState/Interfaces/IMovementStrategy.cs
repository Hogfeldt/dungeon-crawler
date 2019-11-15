namespace ServerApp.GameState
{
    public interface IMovementStrategy
    {
        Character.Direction GenerateMove();
    }
}
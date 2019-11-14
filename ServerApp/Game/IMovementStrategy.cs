namespace ServerApp.Game
{
    public interface IMovementStrategy
    {
        Character.Direction GenerateMove();
    }
}
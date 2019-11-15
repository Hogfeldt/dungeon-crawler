namespace ServerApp.GameState
{
    public interface IGameState
    {
        Player Player { get; }
        IMap Map { get; }
    }
}
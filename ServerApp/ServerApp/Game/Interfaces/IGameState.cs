namespace ServerApp.Game
{
    public interface IGameState
    {
        Player Player { get; }
        IMap Map { get; }
    }
}
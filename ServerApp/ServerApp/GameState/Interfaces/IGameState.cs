namespace ServerApp.GameState
{
    public interface IGameState
    {
        IPlayer Player { get; }
        IMap Map { get; }
    }
}
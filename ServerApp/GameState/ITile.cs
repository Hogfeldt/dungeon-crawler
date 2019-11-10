namespace ServerApp.GameState
{
    public interface ITile
    {
        bool Walkable { get; set; }
        bool Occupied { get; set; }
    }
}
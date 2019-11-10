namespace ServerApp.GameState
{
    public class Tile: ITile
    {
        public bool Walkable { set; get; }
        public bool Occupied { set; get; }
    }
}
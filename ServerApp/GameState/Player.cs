namespace ServerApp.GameState
{
    public class Player: Character
    {
        public int Layer { get; private set; }

        public Player()
        {
            Layer = 0;
        }

        public void Ascend()
        {
            Layer -= 1;
        }

        public void Descend()
        {
            Layer += 1;
        }
    }
}
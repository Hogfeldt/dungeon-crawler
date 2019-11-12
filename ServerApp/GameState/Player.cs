namespace ServerApp.GameState
{
    public class Player: Character
    {
        public int Layer { get; private set; }

        public Player(uint xPos, uint yPos, uint health)
        {
            this.XPos = xPos;
            this.YPos = yPos;
            this.Health = health;
            Layer = 0;
        }

        public void Ascend()
        {
            if (Layer > 0) {
                Layer -= 1;
            }
        }

        public void Descend()
        {
            Layer += 1;
        }
    }
}
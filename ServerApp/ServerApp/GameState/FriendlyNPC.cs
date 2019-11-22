namespace ServerApp.GameState
{
    public class FriendlyNPC: NPC
    {
        public FriendlyNPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "Friendly McName") : base(position, stats, movementStrategy, name)
        {

        }
    }
}

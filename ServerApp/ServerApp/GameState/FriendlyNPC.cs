using ServerApp.GameState.Interfaces;

namespace ServerApp.GameState
{
    public class FriendlyNPC: INpc
    {
        public FriendlyNPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "Friendly McName") 
        {
            this.Position = position;
            this.Stats = stats;
            this.MovementStrategy = movementStrategy;
            this.Name = name;
        }

        public string Name { get; }
        public IPosition Position { get; set; }
        public IStats Stats { get; set; }
        public Direction NextMove { get; }
        public bool Alive { get; }
        public IMovementStrategy MovementStrategy { get; }

        public void DropLoot()
        {
            throw new System.NotImplementedException();
        }

        public int TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }
    }
}

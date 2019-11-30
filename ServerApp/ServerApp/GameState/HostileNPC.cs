using ServerApp.GameState.Interfaces;

namespace ServerApp.GameState
{
    public class HostileNPC : INpc
    {
        public int DroppedGold { get; set; } = 0;
        public int DroppedExperience { get; private set; }
        public string Name { get; }
        public IMovementStrategy MoveStrategy { get; }
        public IPosition Position { get; set; }
        public IStats Stats { get; set; }
        public Character.Direction NextMove { get; }
        public bool Alive => Stats.CurrentHealth <= 0;

        public HostileNPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "Hostile McGuy", int droppedGold = 0)
        {
            this.Position = position;
            this.Stats = stats;
            this.MoveStrategy = movementStrategy;
            this.Name = name;
            this.DroppedGold = droppedGold;
            DroppedExperience = stats.MaxHealth * stats.Damage;
        }
        public void DropToCharacter(Player player)
        {
            player.AddGold(DroppedGold);
            player.AddExperience(DroppedExperience);
        }

        
        public int TakeDamage(int damage)
        {
            Stats.TakeDamage(damage);
            return damage;
        }
    }
}

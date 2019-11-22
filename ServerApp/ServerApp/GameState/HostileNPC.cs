namespace ServerApp.GameState
{
    public class HostileNPC : NPC
    {
        public int DroppedGold { get; set; } = 0;
        public int DroppedExperience { get; private set; }

        public HostileNPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "Hostile McGuy", int droppedGold = 0)
            : base(position, stats, movementStrategy, name)
        {
            this.DroppedGold = droppedGold;
            DroppedExperience = stats.MaxHealth * stats.Damage;
        }
        public void DropToCharacter(Player player)
        {
            player.AddGold(DroppedGold);
            player.AddExperience(DroppedExperience);
        }

    }
}

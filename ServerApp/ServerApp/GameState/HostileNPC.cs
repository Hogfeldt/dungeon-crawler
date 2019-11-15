using System;

namespace ServerApp.GameState
{
    public class HostileNPC : NPC
    {
        public int DroppedGold { get; set; } = 0;

        public HostileNPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "Hostile McGuy", int droppedGold = 0)
            : base(position, stats, movementStrategy, name)
        {
            this.DroppedGold = droppedGold;
        }
        public void DropGoldToCharacter(Player player)
        {
            player.AddGold(DroppedGold);
        }
    }
}
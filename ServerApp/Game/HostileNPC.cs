using System;

namespace ServerApp.Game
{
    public class HostileNPC : NPC
    {
        public int DroppedGold { get; set; } = 0;

        public HostileNPC(Position position, Stats stats, IMovementStrategy movementStrategy, string name = "Hostile McGuy", int droppedGold = 0)
            : base(position, stats, movementStrategy, name)
        {
            this.DroppedGold = droppedGold;
        }
        public void DropGoldToChar(Player player)
        {
            player.AddGold(DroppedGold);
        }
    }
}
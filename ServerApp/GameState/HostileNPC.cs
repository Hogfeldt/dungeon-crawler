using System;

namespace ServerApp.GameState
{
    public class HostileNPC : Character
    {
        public int DroppedGold { get; set; } = 0;

        public HostileNPC(Position position, Stats stats, string name = "Hostile McGuy", int droppedGold = 0) : base(position, stats, name)
        {
            this.DroppedGold = droppedGold;
        }
        public void DropGoldToChar(Player player)
        {
            player.AddGold(DroppedGold);
        }
    }
}
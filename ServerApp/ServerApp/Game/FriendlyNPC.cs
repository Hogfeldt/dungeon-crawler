using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace ServerApp.Game
{
    public class FriendlyNPC: NPC
    {
        public FriendlyNPC(Position position, Stats stats, IMovementStrategy movementStrategy, string name = "Friendly McName") : base(position, stats, movementStrategy, name)
        {

        }
    }
}
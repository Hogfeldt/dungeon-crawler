using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace ServerApp.GameState
{
    public class FriendlyNPC: Character
    {
        public FriendlyNPC(Position position, Stats stats, string name = "Friendly McName") : base(position, stats, name)
        {

        }
    }
}
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using ServerApp.Game;

namespace ServerApp.Game
{
    public abstract class NPC: Character
    {
        public IMovementStrategy _movementStrategy;

        protected NPC(Position position, Stats stats, IMovementStrategy movementStrategy, string name = "NPC McDefaultName"): base(position, stats, name)
        {
            this._movementStrategy = movementStrategy;
        }

        public void GenerateMove()
        {
            this.NextMove = _movementStrategy.GenerateMove();
        }
    }
}
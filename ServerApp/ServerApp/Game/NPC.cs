using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using ServerApp.Game;

namespace ServerApp.Game
{
    public abstract class NPC: Character
    {
        private IMovementStrategy _movementStrategy;

        protected NPC(IPosition position, IStats stats, IMovementStrategy movementStrategy, string name = "NPC McDefaultName"): base(position, stats, name)
        {
            this._movementStrategy = movementStrategy;
        }

        public void GenerateMove()
        {
            this.NextMove = _movementStrategy.GenerateMove();
        }

        public void SetMovementStrategy(IMovementStrategy movementStrategy)
        {
            this._movementStrategy = movementStrategy;
        }
    }
}
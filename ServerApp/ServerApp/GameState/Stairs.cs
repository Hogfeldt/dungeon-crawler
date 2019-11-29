using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.GameState
{
    public class Stairs : IInteractiveObject
    {
        private readonly bool _descending;
        public Stairs(bool descending)
        {
            _descending = descending;
        }
        public void interact(IGameState gameState)
        {
            // This is bad, but functionality needs to move out of Layer
            int level;

            if (_descending)
            {
                level = -1;
            }
            else
            {
                level = 1;
            }

            gameState.Map.MovePlayerToNewLayer(gameState.Map.CurrentLayerNumber - level, _descending);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class InteractionHandler : IInteractionHandler
    {
        public void Interact(IGameState state)
        {
            IPlayer player = state.Player;
            IInteractiveObject[,] interactiveObjects = state.Map.GetCurrentLayer().InteractiveObjects;

            interactiveObjects[player.Position.X, player.Position.Y]?.interact(state);
        }
    }
}

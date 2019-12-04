using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface ITurnExecutioner
    {
        IGameState ExecuteTurn(IGameState state);
    }
}

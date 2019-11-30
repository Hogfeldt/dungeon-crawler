using System.Collections.Generic;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IMoveExecutioner
    {
        void ExecuteMoves(Queue<ICharacter> turns, ILayer layer);
    }
}
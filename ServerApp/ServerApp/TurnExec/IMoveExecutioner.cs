using System.Collections.Generic;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface IMoveExecutioner
    {
        List<ICharacter> ExecuteMoves(Queue<ICharacter> turns, Layer layer);
    }
}
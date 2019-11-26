using System.Collections.Generic;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public interface ITurnScheduler
    {
        Queue<ICharacter> Schedule(List<ICharacter> characters);
    }
}
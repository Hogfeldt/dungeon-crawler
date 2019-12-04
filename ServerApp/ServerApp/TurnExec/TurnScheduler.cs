using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerApp.GameState;

namespace ServerApp.TurnExec
{
    public class TurnScheduler : ITurnScheduler
    {
        public Queue<ICharacter> Schedule(List<ICharacter> characters)
        {
            characters.Sort((c1, c2) => c2.Stats.Speed - c1.Stats.Speed);
            return new Queue<ICharacter>(characters);
        }
    }
}

using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace ServerApp.Game
{
    public class GameState : IGameState
    {
        public Player Player => Map.GetPlayer();
        public IMap Map { get; private set; }

        public GameState(IMap map)
        {
            this.Map = map;
        }
    }
}

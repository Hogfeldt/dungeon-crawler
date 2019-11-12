using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace ServerApp.GameState
{
    public class GameState
    {
        public Player Player { get; private set; }
        public IMap Map { get; private set; }

        public GameState(Player player, IMap map)
        {
            this.Player = player;
            this.Map = map;
        }
    }
}

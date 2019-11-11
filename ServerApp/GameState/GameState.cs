using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace ServerApp.GameState
{
    public class GameState
    {
        public List<Character> characters_ { get; private set; } = new List<Character>();
        public IMap map_ { get; private set; }

        public GameState(IMap map)
        {
            this.map_ = map;
        }

        public void AddCharacter(Character character)
        {
            characters_.Add(character);
        }

    }
}
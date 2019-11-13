using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace ServerApp.Game
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

        public List<Character> GetCharactersOnCurrentLayer()
        {
            List<Character> Characters = new List<Character>();
            Characters.Add(Player);
            Characters.AddRange(GetNPCsOnLayer(Player.Layer));

            return Characters;
        }

        public List<NPC> GetNPCsOnLayer(int layer)
        {
            List<NPC> Characters = new List<NPC>();
            foreach (var npc in Map.GetLayer(layer).NPCs)
            {
                if (npc != null)
                {
                    Characters.Add(npc);
                }
            }

            return Characters;
        }
    }
}

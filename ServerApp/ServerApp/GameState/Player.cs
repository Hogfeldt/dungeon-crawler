using System;

namespace ServerApp.GameState
{
    public class Player: Character
    {
        public int Gold { get; private set; }
        public int Xp { get; private set;  }

        public Player(IPosition position, IStats stats, string name = "Player McName", int gold = 15) : base(position, stats, name)
        {
            Gold = gold;
        }

        public void AddExperience(int xp)
        {
            if (xp > 0)
            {
                Xp += xp;
            }
        }

        public bool AddGold(int gold)
        {
            if (gold > 0)
            {
                Gold += gold;
                return true;
            }

            return false;
        }

        public bool RemoveGold(int gold)
        {
            if (gold < 0) return false;

            if(Gold < gold)
            {
                return false;
            }
            
            Gold -= gold;
            return true;
        }

        public void SetNextMove(Character.Direction direction)
        {
            NextMove = direction;
        }
    }
}

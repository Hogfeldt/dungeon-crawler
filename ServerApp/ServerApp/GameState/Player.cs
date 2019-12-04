using System;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Player: IPlayer
    {
        public string Name { get; }
        public IPosition Position { get; set; }
        public IStats Stats { get; set; }
        public Direction NextMove { get; set; }

        public bool Alive => this.Stats.CurrentHealth > 0;

        public int TakeDamage(int damage)
        {
            Stats.ReduceHealt(damage);
            return damage;
        }
        public int Gold { get; set; }
        public int Experience { get; set; } = 0;

        [JsonConstructor]
        public Player(IPosition position, IStats stats, string name = "Player McName", int gold = 0) 
        {
            Position = position;
            Stats = stats;
            Name = name;
            Gold = gold;
        }

        public void AddExperience(int xp)
        {
            if (xp > 0)
            {
                Experience += xp;
            }
        }

        public void AddGold(int gold)
        {
            if (gold > 0)
            {
                Gold += gold;
            }
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

        public void SetNextMove(Direction direction)
        {
            NextMove = direction;
        }

        public int DropLoot()
        {
            throw new NotImplementedException();
        }
    }
}

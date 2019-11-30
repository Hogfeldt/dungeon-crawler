using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public abstract class Player: IPlayer
    {
     
        public int Gold { get; set; }
        public int Experience { get; set; } = 0;

        protected Player(IPosition position, IStats stats, string name = "Player McName", int gold = 0) 
        {
            this.Position = position;
            this.Stats = stats;
            this.Name = name;
            Gold = gold;
        }

        protected Player(IPosition position, IStats stats, string name = "Player McName", int gold = 0, int experience = 0) 
        {
            this.Position = position;
            this.Stats = stats;
            this.Name = name;
            Experience = experience;
            Gold = gold;
        }


        public void AddExperience(int xp)
        {
            if (xp > 0)
            {
                Experience += xp;
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

        public string Name { get; }
        public IPosition Position { get; set; }
        public IStats Stats { get; set; }
        public Character.Direction NextMove { get; set; }
        public bool Alive { get; private set; } = true; //ELIAS WHAT HAVE YOU DONE
        public int TakeDamage(int damage)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlayer : ICharacter
    {
        int Gold { get; set; }
        int Experience { get; set; }
        void SetNextMove(Character.Direction direction);
        bool AddGold(int gold);


    }
}

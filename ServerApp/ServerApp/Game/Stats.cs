using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApp.Game
{
    public class Stats : IStats
    {
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int Damage { get; set; } = 0;
        public int Speed { get; set; } = 0;

        public Stats(int health = 1, int damage = 0, int speed = 0)
        {
            this.MaxHealth = health;
            this.CurrentHealth = health;
            this.Damage = damage;
            this.Speed = speed;
        }
    }
}

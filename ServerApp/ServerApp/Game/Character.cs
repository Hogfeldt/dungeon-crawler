using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace ServerApp.Game
{
    public abstract class Character
    {
        public string Name { protected set; get; }
        public Position Position { set; get; }
        public Stats Stats { set; get; }
        public Direction NextMove { protected set; get; }

        public bool Alive { protected set; get; } = true;

        public enum Direction
        {
            None,
            Up,
            Down,
            Left,
            Right
        }

        protected Character(Position position, Stats stats, string name = "Character McDefaultName")
        {
            this.Position = position;
            this.Stats = stats;
            this.Name = name;
            this.NextMove = Direction.None;
        }

        public int TakeDamage(int damage)
        {
            this.Stats.CurrentHealth -= damage;
            if (this.Stats.CurrentHealth < 0)
            {
                this.Stats.CurrentHealth = 0;
                this.Alive = false;
            }

            return this.Stats.CurrentHealth;
        }
    }
}
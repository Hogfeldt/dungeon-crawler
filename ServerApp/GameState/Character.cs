using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace ServerApp.GameState
{
    public abstract class Character
    {
        public Position Position { protected set; get; }
        public uint MaxHealth { protected set; get; }
        public uint CurrentHealth { protected set; get; } = 0;
        public uint Damage { protected set; get; }
        public uint Speed { protected set; get; }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        protected Character(uint xPos = 0, uint yPos = 0, uint maxHealth = 0, uint damage = 0, uint speed = 0)
        {
            this.Position = new Position(xPos, yPos);
            this.MaxHealth = maxHealth;
            this.CurrentHealth = maxHealth;
            this.Damage = damage;
            this.Speed = speed;
        }

        public virtual void Move(Direction direction)
        {
            
        }

        public void SetPos(Position position)
        {
            this.Position = position;
        }
    }
}
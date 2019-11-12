using System;
using System.Runtime.InteropServices.ComTypes;
using System.Threading;

namespace ServerApp.GameState
{
    public abstract class Character
    {
        public Position Position { protected set; get; }
        public Stats Stats { protected set; get; }
        public string Name { protected set; get; }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        protected Character(Position position, Stats stats, string name = "Character McName")
        {
            this.Position = position;
            this.Stats = stats;
            this.Name = name;
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
using System;
using System.Threading;

namespace ServerApp.GameState
{
    public abstract class Character
    {
        public uint XPos { protected set; get; }
        public uint YPos { protected set; get; }
        public uint Health { protected set; get; }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        protected Character()
        {
            
        }

        public virtual void Move(Direction direction)
        {
            
        }

        public void SetPos(uint XPos, uint YPos)
        {
            this.XPos = XPos;
            this.YPos = XPos;
        }


    }
}
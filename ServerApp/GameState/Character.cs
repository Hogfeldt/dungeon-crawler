using System;
using System.Threading;

namespace ServerApp.GameState
{
    public abstract class Character: ICharacter
    {
        public uint XPos { private set; get; }
        public uint YPos { private set; get; }
        public int Layer { private set; get; }
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

        public void SetPos(uint XPos, uint YPos, int Layer)
        {
            this.XPos = XPos;
            this.YPos = XPos;
            this.Layer = Layer;
        }

        public void SetPos(uint XPos, uint YPos)
        {
            this.XPos = XPos;
            this.YPos = XPos;
        }


    }
}
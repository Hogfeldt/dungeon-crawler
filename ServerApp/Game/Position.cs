using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServerApp.Game
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Position(Position position)
        {
            this.X = position.X;
            this.Y = position.Y;
        }

        public Position(Position position, int xOff, int yOff)
        {
            this.X = position.X - xOff;
            this.Y = position.Y - yOff;
        }
    }
}

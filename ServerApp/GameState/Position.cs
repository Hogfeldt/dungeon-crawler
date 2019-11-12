using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace ServerApp.GameState
{
    public class Position
    {
        public uint X { get; set; }
        public uint Y { get; set; }

        public Position()
        {
            this.X = 0;
            this.Y = 0;
        }
        public Position(uint x, uint y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}

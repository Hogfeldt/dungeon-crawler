using System;

namespace ServerApp.GameState
{
    public class RandomMovementStrategy: IMovementStrategy
    {
        private static readonly Random Rand = new Random();
        public Direction GenerateMove()
        {
            return (Direction) Rand.Next(1, 4);
        }
    }
}
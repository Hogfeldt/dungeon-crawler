﻿using System;

namespace ServerApp.Game
{
    public class RandomMovementStrategy: IMovementStrategy
    {
        private static readonly Random Rand = new Random();
        public Character.Direction GenerateMove()
        {
            return (Character.Direction) Rand.Next(1, 4);
        }
    }
}
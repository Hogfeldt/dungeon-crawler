﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class ConcretePlayer : Player
    {
        public ConcretePlayer(IPosition position, IStats stats, string name = "Player McName", int gold = 0) : base(position, stats, name, gold)
        {
        }

        [JsonConstructor]
        public ConcretePlayer(IPosition position, IStats stats, string name = "Player McName", int gold = 0, int experience = 0) : base(position, stats, name, gold, experience)
        {
        }
    }
}
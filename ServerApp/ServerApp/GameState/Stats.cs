﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ServerApp.GameState
{
    public class Stats : IStats
    {
        public int MaxHealth { get; set; }
        public int Damage { get; set; }
        public int CurrentHealth { get; private set; }



        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }

        public void GainHealth(int health)
        {
            CurrentHealth = Math.Min(MaxHealth, CurrentHealth + health);
        }

        public int Speed { get; set; } = 0;

        public Stats(int health = 1, int damage = 0, int speed = 0)
        {
            this.MaxHealth = health;
            this.CurrentHealth = health;
            this.Damage = damage;
            this.Speed = speed;
        }

        [JsonConstructor]
        public Stats(int maxHealth, int currentHealth, int damage, int speed)
        {
            this.MaxHealth = maxHealth;
            this.CurrentHealth = currentHealth;
            this.Damage = damage;
            this.Speed = speed;
        }
    }
}


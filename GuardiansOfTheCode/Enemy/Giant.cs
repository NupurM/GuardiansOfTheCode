﻿using System;
using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemy
{
    public class Giant : IEnemy
    {
        public Giant(int health, int level)
        {
            Health = health;
            Level = level;
        }

        public int Health { get; set; }
        public int Level { get; }
        public int OvertimeDamage { get; set; }
        public int Armor { get; set; }
        public int FireDamage { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedFor { get; set; }

        public void Attack(PrimaryPlayer player)
        {
            player.Health -= 20;
            Console.WriteLine($"Giant attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Giant defending {player.Name}");
        }
    }
}

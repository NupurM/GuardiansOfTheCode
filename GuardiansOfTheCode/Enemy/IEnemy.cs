﻿using GuardiansOfTheCode.Player;

namespace GuardiansOfTheCode.Enemy
{
    public interface IEnemy
    {
        int Health { get; set; }
        int Level { get; }
        int OvertimeDamage { get; set; }
        int Armor { get; set; }
        int FireDamage { get; set; }
        bool Paralyzed { get; set; }
        int ParalyzedFor { get; set; }

        void Attack(PrimaryPlayer player);
        void Defend(PrimaryPlayer player);
    }
}

using GuardiansOfTheCode.Player;
using System;

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

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Giant attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Giant defending {player.Name}");
        }
    }
}

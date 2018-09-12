using GuardiansOfTheCode.Player;
using System;

namespace GuardiansOfTheCode.Enemy
{
    public class Zombie : IEnemy
    {
        public Zombie(int health, int level)
        {
            Health = health;
            Level = level;
        }

        public int Health { get; set; }
        public int Level { get; }

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Zombie defending {player.Name}");
        }
    }
}

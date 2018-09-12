using GuardiansOfTheCode.Player;
using System;

namespace GuardiansOfTheCode.Enemy
{
    public class Werewolf : IEnemy
    {
        public Werewolf(int health, int level)
        {
            Health = health;
            Level = level;
        }

        public int Health { get; set; }

        /// <summary>
        /// A Property with no setter is read only.
        /// Read only properties can be assigned a value
        /// inline during definition or through the constructor.
        /// </summary>
        public int Level { get; }

        public int OvertimeDamage { get; set; }
        public int Armor { get; set; }
        public int FireDamage { get; set; }
        public bool Paralyzed { get; set; }
        public int ParalyzedFor { get; set; }

        public void Attack(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf attacking {player.Name}");
        }

        public void Defend(PrimaryPlayer player)
        {
            Console.WriteLine($"Werewolf defending {player.Name}");
        }
    }
}

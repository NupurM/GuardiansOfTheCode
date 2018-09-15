using System;
using GuardiansOfTheCode.Enemy;

namespace GuardiansOfTheCode.Weapon
{
    public class FireStaff : IWeapon
    {
        public FireStaff(int damage, int fireDamage)
        {
            Damage = damage;
            _fireDamage = fireDamage;
        }

        public int Damage { get; }
        private readonly int _fireDamage;

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.OvertimeDamage -= _fireDamage;
            Console.WriteLine($"FireStaff attack on {enemy.GetType().Name}");
        }
    }
}
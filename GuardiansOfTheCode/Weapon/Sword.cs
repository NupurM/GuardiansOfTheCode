using System;
using GuardiansOfTheCode.Enemy;

namespace GuardiansOfTheCode.Weapon
{
    public class Sword : IWeapon
    {
        public int Damage { get; }
        public int ArmorDamage { get; }

        public Sword(int damage, int armorDamage)
        {
            Damage = damage;
            ArmorDamage = armorDamage;
        }
        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Armor -= ArmorDamage;
            Console.WriteLine($"Sword attack on {enemy.GetType()}");
        }
    }
}
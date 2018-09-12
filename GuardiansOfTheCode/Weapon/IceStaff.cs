using System;
using GuardiansOfTheCode.Enemy;

namespace GuardiansOfTheCode.Weapon
{
    public class IceStaff : IWeapon
    {
        public IceStaff(int damage, int paralyzedFor)
        {
            Damage = damage;
            _paralyzedFor = paralyzedFor;
        }

        public int Damage { get; }
        private readonly int _paralyzedFor;

        public void Use(IEnemy enemy)
        {
            enemy.Health -= Damage;
            enemy.Paralyzed = true;
            enemy.ParalyzedFor = _paralyzedFor;
            Console.WriteLine($"IceStaff attack on {enemy.GetType()}");
        }
    }
}
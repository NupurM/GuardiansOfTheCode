using System;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Weapon;
using MilkyWeaponLib;

namespace GuardiansOfTheCode.Adapters
{
    public class WeaponAdapter : IWeapon
    {
        private readonly ISpaceWeapon _spaceWeapon;
        public WeaponAdapter(ISpaceWeapon spaceWeapon)
        {
            _spaceWeapon = spaceWeapon;
        }

        public int Damage => _spaceWeapon.ImpactDamage + _spaceWeapon.LaserDamage;

        public void Use(IEnemy enemy)
        {
            Console.WriteLine("\n\n\t  Pew! Pew!" +
                              "\n\t  Pew! Pew!");
            enemy.Health -= _spaceWeapon.Shoot();
        }
    }
}

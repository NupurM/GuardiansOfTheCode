namespace MilkyWeaponLib
{
    public class Blaster : ISpaceWeapon
    {
        public int ImpactDamage => 15;

        public int LaserDamage => 10;

        public int MissChance => 0;
        
        public int Shoot()
        {
            return ImpactDamage + LaserDamage;
        }
    }
}

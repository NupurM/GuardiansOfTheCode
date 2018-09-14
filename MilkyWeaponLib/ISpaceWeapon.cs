namespace MilkyWeaponLib
{
    public interface ISpaceWeapon
    {
        int ImpactDamage { get; }
        int LaserDamage { get; }
        int MissChance { get; }

        int Shoot();
    }
}
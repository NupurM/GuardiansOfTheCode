using GuardiansOfTheCode.Enemy;

namespace GuardiansOfTheCode.Weapon
{
    public interface IWeapon
    {
        int Damage { get; }
        void Use(IEnemy enemy);
    }
}
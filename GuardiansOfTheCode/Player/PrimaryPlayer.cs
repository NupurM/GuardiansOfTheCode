using System.Collections.Generic;
using Common.CardComponent;
using GuardiansOfTheCode.Weapon;

namespace GuardiansOfTheCode.Player
{
    public sealed class PrimaryPlayer
    {
        public static PrimaryPlayer Instance { get; }
        private PrimaryPlayer() { }

        /// <summary>
        /// A static  constructor is called only before
        /// the first initialization of a class.
        /// This is perfect for a singleton.
        /// </summary>
        static PrimaryPlayer()
        {
            Instance = new PrimaryPlayer()
            {
                Name = "Player",
                Level = 1,
                Health = 100,
                Armor = 25
            };
        }

        public string Name { get; set; }
        public int Level { get; set; }
        public IWeapon Weapon { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public List<Card> Cards { get; set; }
    }
}

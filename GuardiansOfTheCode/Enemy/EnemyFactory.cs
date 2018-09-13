﻿namespace GuardiansOfTheCode.Enemy
{
    /// <summary>
    /// Instantiates and returns the correct level of enemy.
    /// Returns one enemy at a time.
    /// </summary>
    public static class EnemyFactory
    {
        public static Werewolf SpawnWerewolf(int areaLevel)
        {
            if (areaLevel < 5)
            {
                return new Werewolf(100, 12);
            }
            else
            {
                return new Werewolf(100, 20);
            }

        }

        public static Giant SpawnGiant(int areaLevel)
        {
            if (areaLevel < 8)
            {
                return new Giant(100, 14);
            }
            else
            {
                return new Giant(100, 32);
            }
        }

        public static Zombie SpawnZombie(int areaLevel)
        {
            if (areaLevel < 3)
            {
                return new Zombie(66, 2);
            }
            else if (areaLevel < 10)
            {
                return new Zombie(66, 5);
            }
            else
            {
                return new Zombie(100, 8);

            }
        }
    }
}

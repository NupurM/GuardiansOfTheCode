using System;
using System.Collections.Generic;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Weapon;

namespace GuardiansOfTheCode.Board
{
    public class GameBoard
    {
        private readonly PrimaryPlayer _player;
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _player.Weapon = new Sword(12, 8);
        }

        public void PlayArea(int level)
        {
            if (level == 1)
            {
                PlayFirstLevel();
            }
        }

        private void PlayFirstLevel()
        {
            const int currentLevel = 1;
            var enemies = new List<IEnemy>();
            for (var i = 0; i < 10; i++)
            {
                enemies.Add(EnemyFactory.SpawnZombie(currentLevel));
            }

            for (var i = 0; i < 3; i++)
            {
                enemies.Add(EnemyFactory.SpawnWerewolf(currentLevel));
            }

            foreach (var enemy in enemies)
            {
                while (enemy.Health > 0 && _player.Health > 0)
                {
                    _player.Weapon.Use(enemy);
                    enemy.Attack(_player);
                    Console.WriteLine($"Enemy health: {enemy.Health} \t Player health: {_player.Health}");
                }
            }
        }
    }
}

﻿using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Player;
using System;
using System.Collections.Generic;

namespace GuardiansOfTheCode.GameBoard
{
    public class GameBoard
    {
        private PrimaryPlayer _player;
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
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
                Console.WriteLine(enemy.GetType());
            }
        }
    }
}

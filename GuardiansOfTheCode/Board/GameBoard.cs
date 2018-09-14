using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
using GuardiansOfTheCode.Adapters;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Weapon;
using MilkyWeaponLib;
using Newtonsoft.Json;

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

        public async Task PlayArea(int level)
        {
            //_player.Cards = (await FetchCards()).ToArray();

            Console.WriteLine("Ready to play Level 1?");
            Console.ReadKey();

            if (level == 1)
            {
                PlayFirstLevel();
            }
            else if (level == -1)
            {
                Console.WriteLine("Play special level?");
                Console.ReadKey();
                PlaySpecialLevel();
            }
        }

        private void PlaySpecialLevel()
        {
            _player.Weapon = new WeaponAdapter(new Blaster());
            _player.Weapon.Use(EnemyFactory.SpawnZombie(55));
        }

        private void PlayFirstLevel()
        {
            const int currentLevel = 1;
            var enemies = new List<IEnemy>();
            for (var i = 0; i < 3; i++)
            {
                enemies.Add(EnemyFactory.SpawnZombie(currentLevel));
            }

            for (var i = 0; i < 1; i++)
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

        private async Task<IEnumerable<Card>> FetchCards()
        {
            using (var http = new HttpClient())
            {
                var cardsJson = await http.GetStringAsync("http://localhost:61540/api/cards");
                return JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson);
            }
        }
    }
}

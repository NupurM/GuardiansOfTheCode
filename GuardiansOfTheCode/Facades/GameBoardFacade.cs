using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common.CardComponent;
using Common.CardDecorators;
using GuardiansOfTheCode.Adapters;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Player;
using GuardiansOfTheCode.Weapon;
using MilkyWeaponLib;
using Newtonsoft.Json;

namespace GuardiansOfTheCode.Facades
{
    public class GameBoardFacade
    {
        private PrimaryPlayer _player;
        private readonly List<IEnemy> _enemies = new List<IEnemy>();
        public async Task Play(PrimaryPlayer player, int level)
        {
            _player = player;
            await AddPlayerCards();
            AddDecoratedCard();
            ConfigurePlayerWeapon();
            LoadZombies(level);
            LoadWerewolves(level);
            LoadGiants(level);
            PlayGame();
        }

        private async Task AddPlayerCards()
        {
            using (var http = new HttpClient())
            {
                var cardsJson = await http.GetStringAsync("http://localhost:61540/api/cards");
                _player.Cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson).ToList();

                Console.WriteLine("\n\nAdding cards:\t   (attack/defense)");
                foreach (var card in _player.Cards)
                {
                    Console.WriteLine($"{card.Name} \t\t   ({card.Attack}/{card.Defense})");
                }
            }
        }

        private void AddDecoratedCard()
        {
            Console.WriteLine("\n\nAdding a decorated card:");
            Card decoratedCard = new Card("Soldier", 10, 15);
            decoratedCard = new AttackDecorator(decoratedCard, "Sword", 15);
            decoratedCard = new AttackDecorator(decoratedCard, "Amulet", 5);
            decoratedCard = new DefenseDecorator(decoratedCard, "Helmet", 10);
            decoratedCard = new DefenseDecorator(decoratedCard, "Heavy Armor", 45);
            _player.Cards.Add(decoratedCard);
            Console.WriteLine($"{decoratedCard.Name}\t\t({decoratedCard.Attack}/{decoratedCard.Defense})");
        }

        private void ConfigurePlayerWeapon()
        {
            while (true)
            {
                Console.WriteLine("\n\nPick a weapon: \n" +
                                  "1. Sword \n" +
                                  "2. Fire Staff \n" +
                                  "3. Ice Staff\n");
                char choice = Console.ReadKey().KeyChar;
                switch (choice)
                {
                    case '1':
                        _player.Weapon = new Sword(15, 15);
                        return;
                    case '2':
                        _player.Weapon = new FireStaff(30, 20);
                        return;
                    case '3':
                        _player.Weapon = new IceStaff(15, 2);
                        return;
                    case '0':
                        _player.Weapon = new WeaponAdapter(new Blaster());
                        break;
                    default:
                        Console.WriteLine("Invalid input.");
                        break;
                }
            }
        }

        private void LoadZombies(int areaLevel)
        {
            int count;
            if (areaLevel == 1) count = 1;
            else if (areaLevel < 3) count = 5;
            else if (areaLevel < 10) count = 20;
            else count = 30;

            for (int i = 0; i < count; i++)
            {
                _enemies.Add(EnemyFactory.SpawnZombie(areaLevel));
            }
        }

        private void LoadWerewolves(int areaLevel)
        {
            int count;
            if (areaLevel == 1) count = 1;
            else if (areaLevel < 3) count = 3;
            else if (areaLevel < 10) count = 10;
            else count = 15;

            for (int i = 0; i < count; i++)
            {
                _enemies.Add(EnemyFactory.SpawnWerewolf(areaLevel));
            }
        }

        private void LoadGiants(int areaLevel)
        {
            int count;
            if (areaLevel == 1) count = 0;
            else if (areaLevel < 3) count = 3;
            else if (areaLevel < 3) count = 1;
            else if (areaLevel < 10) count = 2;
            else count = 3;

            for (int i = 0; i < count; i++)
            {
                _enemies.Add(EnemyFactory.SpawnGiant(areaLevel));
            }
        }

        private void PlayGame()
        {
            Console.Write("\n\nShow battle? y/n    ");
            if (Console.ReadKey().KeyChar == 'y')
            {
                foreach (var enemy in _enemies)
                {
                    Console.WriteLine("\n\n");
                    while (enemy.Health > 0 && _player.Health > 0)
                    {
                        _player.Weapon.Use(enemy);
                        enemy.Attack(_player);
                        Console.WriteLine($"Player health: {_player.Health} \t Enemy health: {enemy.Health}");
                    }
                }
            }

            string gameResult = _player.Health > 0 ? "You won!" : "You lost!";
            Console.WriteLine($"\n\n\t  {gameResult}");
        }
    }
}
using System;
using System.Threading.Tasks;
using GuardiansOfTheCode.Adapters;
using GuardiansOfTheCode.Enemy;
using GuardiansOfTheCode.Facades;
using GuardiansOfTheCode.Player;
using MilkyWeaponLib;

namespace GuardiansOfTheCode.Board
{
    public class GameBoard
    {
        private readonly GameBoardFacade _gameBoardFacade;
        private readonly PrimaryPlayer _player;
        public GameBoard()
        {
            _player = PrimaryPlayer.Instance;
            _gameBoardFacade = new GameBoardFacade();
        }

        public async Task PlayArea(int level)
        {
            if (level == -1)
            {
                Console.Write("\nPlay special level? y/n    ");
                if (Console.ReadKey().KeyChar == 'y')
                {
                    PlaySpecialLevel();
                }
            }
            else
            {
                Console.Write($"\nReady to play Level {level}? y/n    ");
                if (Console.ReadKey().KeyChar == 'y')
                {
                 await _gameBoardFacade.Play(_player, level);
                }
            }
        }

        private void PlaySpecialLevel()
        {
            _player.Weapon = new WeaponAdapter(new Blaster());
            Console.WriteLine($"\n\n\nUsing space weapon: Blaster - {_player.Weapon.Damage} damage");

            _player.Weapon.Use(EnemyFactory.SpawnZombie(55));
        }
    }
}

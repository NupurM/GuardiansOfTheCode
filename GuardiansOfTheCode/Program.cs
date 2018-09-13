using System;
using GuardiansOfTheCode.Board;

namespace GuardiansOfTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //var player = PrimaryPlayer.Instance;
            //Console.WriteLine($"Player: {player.Name} - Level {player.Level} ");

            var board = new GameBoard();
            board.PlayArea(1);

            Console.WriteLine("\n\n\t\t**Game Over**\n\n");
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }
    }
}

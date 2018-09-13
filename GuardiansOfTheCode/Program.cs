using GuardiansOfTheCode.Player;
using System;
using GuardiansOfTheCode.GameBoard;

namespace GuardiansOfTheCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var player = PrimaryPlayer.Instance;
            //Console.WriteLine($"Player: {player.Name} - Level {player.Level} ");

            var board = new GameBoard.GameBoard();
            board.PlayArea(1);

            Console.WriteLine("\n\n\t\t**Game Over**\n\n");
            Console.Write("Press any key to continue..");
            Console.ReadKey();
        }
    }
}

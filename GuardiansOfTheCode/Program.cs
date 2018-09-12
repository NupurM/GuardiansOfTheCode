using GuardiansOfTheCode.Player;
using System;

namespace GuardiansOfTheCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var player = PrimaryPlayer.Instance;
            Console.WriteLine($"Player: {player.Name} - Level {player.Level} ");

            Console.ReadKey();
        }
    }
}

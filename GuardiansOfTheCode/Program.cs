using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common;
using Common.Decorators;
using GuardiansOfTheCode.Board;

namespace GuardiansOfTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\n\n\t\t**Starting Game**\n\n");

                //var player = PrimaryPlayer.Instance;
                //Console.WriteLine($"Player: {player.Name} - Level {player.Level} ");

                //TestApiConnection().Wait();
                var board = new GameBoard();
                board.PlayArea(-1).Wait();

                TestDecorators();

                Console.WriteLine("\n\n\t\t**Game Over**\n\n");
                Console.Write("Press any key to continue..");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static async Task TestApiConnection()
        {
            const int maxAttempts = 20;
            const int attemptInterval = 2000;

            using (var http = new HttpClient())
            {
                for (var i = 0; i < maxAttempts; i++)
                {
                    try
                    {
                        var response = await http.GetAsync("http://localhost:61540/api/values");
                        if (response.IsSuccessStatusCode)
                        {
                            return;
                        }
                        Console.WriteLine("Lost connection to the server. Attempting to re-connect");
                        Thread.Sleep(attemptInterval);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Failed to initialize game.\n" + e.Message);
                    }
                }
                throw new Exception("Failed to connect to the server");
            }

        }

        private static void TestDecorators()
        {
            Card soldier = new Card("Soldier", 25, 20);
            soldier = new AttackDecorator(soldier, "Sword", 15);
            soldier = new AttackDecorator(soldier, "Amulet", 5);
            soldier = new DefenseDecorator(soldier, "Helmet", 10);
            soldier = new DefenseDecorator(soldier, "Heavy Armor", 45);
            Console.WriteLine($"Final stats Soldier: {soldier.Attack}/{soldier.Defense}");
        }
    }
}

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
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

                TestApiConnection().Wait();
                //var player = PrimaryPlayer.Instance;
                //Console.WriteLine($"Player: {player.Name} - Level {player.Level} ");

                var board = new GameBoard();
                board.PlayArea(1).Wait();

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
    }
}

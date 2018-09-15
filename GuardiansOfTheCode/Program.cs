using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Common.CardComponent;
using GuardiansOfTheCode.Board;

namespace GuardiansOfTheCode
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\t**Starting Game**\n");

                TestApiConnection().Wait();
                //TestComposite();
                var board = new GameBoard();
                board.PlayArea(1).Wait();

                Console.WriteLine("\n\n\t**Game Over**\n\n");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.Write("Press any key to continue..");
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
                        Console.WriteLine("Failed to initialize game.\n" + e.Message + "\nIs the API running?\n");
                    }
                }
                throw new Exception("Failed to connect to the server");
            }
        }

        private static void TestComposite()
        {
            CardDeck deck = new CardDeck();
            CardDeck attackDeck = new CardDeck();
            CardDeck defenseDeck = new CardDeck();

            attackDeck.Add(new Card("Basic Infantry", 12, 0));
            attackDeck.Add(new Card("Cavalry Unit", 32, 5));

            defenseDeck.Add(new Card("Wooden Shield", 0, 6));
            defenseDeck.Add(new Card("Iron Shield", 0, 9));
            defenseDeck.Add(new Card("Royal Armor", 0, 40));

            deck.Add(new Card("Small Beast", 16, 25));
            deck.Add(new Card("High Elf", 20, 10));
            deck.Add(attackDeck);
            deck.Add(defenseDeck);

            Console.WriteLine(deck.Display());
        }
    }
}

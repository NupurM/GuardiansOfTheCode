using System.Collections.Generic;
using Common;

namespace Api.Services
{
    public class CardService : ICardService
    {
        public IEnumerable<Card> FetchCards()
        {
            return new List<Card>
            {
                new Card("Shadow Wraith", 90, 80),
                new Card("Puppet of Doom", 64, 91),
                new Card("Lost Soul", 77, 61),
                new Card("Plague Druid", 55, 57),
                new Card("Rage Dragon", 90, 95)
            };
        }
    }
}

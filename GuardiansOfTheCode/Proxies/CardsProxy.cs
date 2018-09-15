using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common.CardComponent;
using Newtonsoft.Json;

namespace GuardiansOfTheCode.Proxies
{
    public class CardsProxy
    {
        private readonly HttpClient _http;
        private IEnumerable<Card> _cards;
        public CardsProxy()
        {
            _http = new HttpClient();
        }

        public async Task<IEnumerable<Card>> GetCards()
        {
            if (_cards == null)
            {
                await FetchCards();
            }
            return _cards;
        }

        private async Task FetchCards()
        {
            using (var http = new HttpClient())
            {
                var cardsJson = await http.GetStringAsync("http://localhost:61540/api/cards");
                _cards = JsonConvert.DeserializeObject<IEnumerable<Card>>(cardsJson).ToList();
            }
        }
    }
}
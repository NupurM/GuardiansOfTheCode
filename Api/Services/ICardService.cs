using System.Collections.Generic;
using Common.CardComponent;

namespace Api.Services
{
    public interface ICardService
   {
       IEnumerable<Card> FetchCards();
   }
}

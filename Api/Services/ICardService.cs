using System.Collections.Generic;
using Common;

namespace Api.Services
{
    public interface ICardService
   {
       IEnumerable<Card> FetchCards();
   }
}

using Common;
using System.Collections.Generic;

namespace Api.Services
{
    public interface ICardService
   {
       IEnumerable<Card> FetchCards();
   }
}

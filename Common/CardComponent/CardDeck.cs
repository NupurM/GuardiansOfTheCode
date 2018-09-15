using System.Collections.Generic;
using System.Text;

namespace Common.CardComponent
{
    public class CardDeck : ICardComponent
    {
        private readonly List<ICardComponent> _components = new List<ICardComponent>();

        public ICardComponent Get(int index)
        {
            return _components[index];
        }

        public void Add(ICardComponent component)
        {
            _components.Add(component);
        }

        public bool Remove(ICardComponent component)
        {
            return _components.Remove(component);
        }

        public string Display()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var component in _components)
            {
                builder.Append(component.Display());
            }

            return builder.ToString();
        }
    }
}
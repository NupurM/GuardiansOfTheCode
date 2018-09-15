namespace Common.CardComponent
{
    public class Card : ICardComponent
    {
        public Card(string name, int attack, int defense)
        {
            Name = name;
            Attack = attack;
            Defense = defense;
        }

        public virtual string Name { get; }
        public virtual int Attack { get; }
        public virtual int Defense { get; }
        public ICardComponent Get(int index)
        {
            throw new System.NotImplementedException();
        }

        public void Add(ICardComponent component)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ICardComponent component)
        {
            throw new System.NotImplementedException();
        }

        public string Display()
        {
            return $"\n{Name} \t\t   ({Attack}/{Defense})";
        }
    }
}
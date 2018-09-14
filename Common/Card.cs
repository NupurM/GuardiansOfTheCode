namespace Common
{
    public class Card
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
    }
}
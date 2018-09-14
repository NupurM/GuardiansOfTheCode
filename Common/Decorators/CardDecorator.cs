namespace Common.Decorators
{
    public
        class CardDecorator : Card
    {
        protected Card Card;

        protected CardDecorator(Card card, string name, int attack, int defense) : base(name, attack, defense)
        {
            Card = card;
        }

        public override string Name => $"{Card.Name} , {base.Name}";
        public override int Attack => Card.Attack + base.Attack;
        public override int Defense => Card.Defense + base.Defense;
    }
}
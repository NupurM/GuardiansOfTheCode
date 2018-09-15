using Common.CardComponent;

namespace Common.CardDecorators
{
    public class AttackDecorator : CardDecorator
    {
        public AttackDecorator(Card card, string name, int attack) : base(card, name, attack, 0)
        {
        }
    }
}
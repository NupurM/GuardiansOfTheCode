namespace Common.CardComponent
{
    public interface ICardComponent
    {
        ICardComponent Get(int index);
        void Add(ICardComponent component);
        bool Remove(ICardComponent component);
        string Display();
    }
}
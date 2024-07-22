namespace Nymph.Model;

public interface IStrategy
{
    public Seq<Item> SearchItems(State state);
}
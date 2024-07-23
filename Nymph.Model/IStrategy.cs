namespace Nymph.Model;

public interface IStrategy
{
    public Seq<Group> SearchItems(State state);
}
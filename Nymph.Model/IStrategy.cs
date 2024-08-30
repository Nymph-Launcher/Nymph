namespace Nymph.Model;

/// <summary>
///     Interface for strategy classes. Strategy classes are used to search for possible moves given a state.
/// </summary>
public interface IStrategy
{
    /// <summary>
    ///     Searches for the possible moves given a state.
    /// </summary>
    /// <param name="state">State based on.</param>
    /// <returns>Possible groups used for further move.</returns>
    public Seq<Group> Search(State state);
}
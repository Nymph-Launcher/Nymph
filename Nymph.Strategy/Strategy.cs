using Nymph.Model;

namespace Nymph.Strategy;

/// <summary>
///     The strategy to search groups.
/// </summary>
public class Strategy : IStrategy
{
    /// <summary>
    ///     Search groups by the state.
    /// </summary>
    /// <param name="state">State.</param>
    /// <returns>Groups.</returns>
    public Seq<Group> Search(State state)
    {
        throw new NotImplementedException();
    }
}
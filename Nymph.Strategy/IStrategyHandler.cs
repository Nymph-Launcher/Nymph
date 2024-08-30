using Nymph.Model;

namespace Nymph.Strategy;

/// <summary>
///     Interface for strategy handlers.
/// </summary>
public interface IStrategyHandler
{
    /// <summary>
    ///     Handles the state and returns the groups.
    /// </summary>
    /// <param name="state">State.</param>
    /// <returns>Groups returned.</returns>
    Seq<Group> HandleState(AnalyzableState state);
}
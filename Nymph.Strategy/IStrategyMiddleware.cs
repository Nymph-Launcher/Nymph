using Nymph.Model;

namespace Nymph.Strategy;

/// <summary>
///     A middleware that can modify the state and groups of a strategy handler.
/// </summary>
public interface IStrategyMiddleware
{
    /// <summary>
    ///     Modify the state of the strategy handler.
    /// </summary>
    /// <param name="state">State being modified.</param>
    /// <returns>State returned.</returns>
    AnalyzableState Modify(AnalyzableState state);

    /// <summary>
    ///     Modify the groups of the strategy handler.
    /// </summary>
    /// <param name="groups">Groups being modified.</param>
    /// <returns>Groups returned.</returns>
    Seq<Group> Modify(Seq<Group> groups);
}
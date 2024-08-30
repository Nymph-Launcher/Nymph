namespace Nymph.Model.Strategy;

/// <summary>
///     Represents the state with additional information for being analyzed.
/// </summary>
/// <param name="PossibleConstraintItems">Possible constraint items.</param>
/// <param name="PossibleBindings">Possible binding items.</param>
/// <param name="PossibleSearches">Possible search text.</param>
public record AnalyzableState(
    IEnumerable<TrackableItem> PossibleConstraintItems,
    IEnumerable<TrackableItem> PossibleBindings,
    IEnumerable<TrackableItem<Item.Atom<string>>> PossibleSearches)
{
    /// <summary>
    ///     Converts the state to an analyzable state.
    /// </summary>
    /// <param name="state">State.</param>
    /// <returns>Analyzable state.</returns>
    public static AnalyzableState FromState(State state)
    {
        return new AnalyzableState(
            state.Constraint.Match<IEnumerable<TrackableItem>>(
                constraint => [TrackableItem.FromItem(constraint)],
                () => []
            ),
            state.Items.AsEnumerable().Select(TrackableItem.FromItem),
            [TrackableItem<Item.Atom<string>>.FromItem(new Item.Atom<string>(state.Search))]);
    }
}
using ReactiveUI;
using ReactiveUnit = System.Reactive.Unit;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// ViewModel for a candidate item.
/// </summary>
/// <typeparam name="TItem">Type of the candidate item.</typeparam>
public interface ICandidateItemViewModel<out TItem> : IReactiveObject where TItem : Model.Item
{
    /// <summary>
    /// Candidate item.
    /// </summary>
    TItem Item { get; }

    /// <summary>
    /// Choose the candidate item.
    /// </summary>
    ReactiveCommand<ReactiveUnit, ReactiveUnit> ChooseCommand { get; }
}
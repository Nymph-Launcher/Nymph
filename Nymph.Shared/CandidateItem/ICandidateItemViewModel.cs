using ReactiveUI;
using ReactiveUnit = System.Reactive.Unit;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Base for both rendered and container candidate view models.
/// </summary>
public interface ICandidateItemViewModel
{
    /// <summary>
    /// Command for choosing the candidate item.
    /// </summary>
    ReactiveCommand<ReactiveUnit, ReactiveUnit> ChooseCommand { get; }
}

/// <summary>
/// ViewModel for a candidate item.
/// </summary>
/// <typeparam name="TItem">Type of the candidate item.</typeparam>
public interface ICandidateItemViewModel<out TItem> : ICandidateItemViewModel where TItem : Model.Item
{
    /// <summary>
    /// Candidate item.
    /// </summary>
    TItem Item { get; }
}
using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// ViewModel for a candidate item.
/// </summary>
/// <typeparam name="TItem">Type of the candidate item.</typeparam>
public interface ICandidateItemViewModel<out TItem> where TItem : Model.Item
{
    /// <summary>
    /// Candidate item.
    /// </summary>
    TItem Item { get; }
}
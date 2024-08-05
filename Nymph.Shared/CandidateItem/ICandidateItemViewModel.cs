using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

public interface ICandidateItemViewModel : IReactiveObject
{
}

/// <summary>
/// ViewModel for a candidate item.
/// </summary>
/// <typeparam name="TItem">Type of the candidate item.</typeparam>
public interface ICandidateItemViewModel<TItem> : ICandidateItemViewModel where TItem : Model.Item
{
}
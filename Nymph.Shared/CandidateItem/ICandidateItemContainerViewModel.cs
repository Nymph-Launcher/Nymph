using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Candidate view model which exposes the inner candidate view model to be rendered.
/// </summary>
public interface ICandidateItemContainerViewModel : IReactiveObject
{
    /// <summary>
    /// Inner view model to be rendered.
    /// </summary>
    ICandidateItemViewModel<Model.Item>? ViewModel { get; set; }

    void SetItem(Model.Item item);
}
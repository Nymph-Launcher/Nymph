using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Candidate view model which exposes the inner candidate view model to be rendered.
/// </summary>
public interface ICandidateItemContainerViewModel : ICandidateItemViewModel
{
    /// <summary>
    /// Inner view model to be rendered.
    /// </summary>
    ICandidateItemViewModel<Model.Item>? ViewModel { get; set; }

    /// <summary>
    /// Set item to be rendered.
    /// </summary>
    /// <param name="item">Item model to be rendered.</param>
    void SetItem(Model.Item item);
}
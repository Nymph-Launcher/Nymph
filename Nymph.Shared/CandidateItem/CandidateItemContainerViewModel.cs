using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Candidate view model which exposes the inner candidate view model to be rendered.
/// </summary>
public class CandidateItemContainerViewModel : ReactiveObject, ICandidateItemContainerViewModel
{
    private ICandidateItemViewModel<Model.Item>? _viewModel;

    /// <summary>
    /// Inner view model to be rendered.
    /// </summary>
    public ICandidateItemViewModel<Model.Item>? ViewModel
    {
        get => _viewModel;
        set => this.RaiseAndSetIfChanged(ref _viewModel, value);
    }

    /// <summary>
    /// Set item to be rendered.
    /// </summary>
    /// <param name="item">Item model to be rendered.</param>
    public void SetItem(Model.Item item)
    {
        var candidateItemViewModel = new CandidateItemViewModelBuilder().Build(item);
        ViewModel = candidateItemViewModel;
    }

    /// <summary>
    /// Construct by providing item model.
    /// </summary>
    /// <param name="item">Item model to be rendered.</param>
    public CandidateItemContainerViewModel(Model.Item item)
    {
        SetItem(item);
    }
}
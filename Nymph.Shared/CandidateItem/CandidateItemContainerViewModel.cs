using Autofac;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Candidate view model which exposes the inner candidate view model to be rendered.
/// </summary>
public class CandidateItemContainerViewModel : ReactiveObject, ICandidateItemContainerViewModel
{
    private ICandidateItemViewModel<Model.Item>? _viewModel;

    private readonly IComponentContext _componentContext;

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
        var candidateItemViewModel = new CandidateItemViewModelBuilder(_componentContext).Build(item);
        ViewModel = candidateItemViewModel;
    }

    /// <summary>
    /// Construct by providing item model.
    /// </summary>
    /// <param name="item">Item model to be rendered.</param>
    /// <param name="componentContext">Container for resolving view models.</param>
    public CandidateItemContainerViewModel(Model.Item item, IComponentContext componentContext)
    {
        _componentContext = componentContext;
        SetItem(item);
    }
}
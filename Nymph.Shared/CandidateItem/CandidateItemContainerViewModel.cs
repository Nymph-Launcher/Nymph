using System.Reactive.Linq;
using Autofac;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem;

/// <inheritdoc cref="ICandidateItemContainerViewModel"/>
public class CandidateItemContainerViewModel : ReactiveObject, ICandidateItemContainerViewModel
{
    private ICandidateItemViewModel<Model.Item>? _viewModel;

    private readonly ICandidateItemViewModelBuilder _candidateItemViewModelBuilder;

    /// <inheritdoc/>
    public ICandidateItemViewModel<Model.Item>? ViewModel
    {
        get => _viewModel;
        set => this.RaiseAndSetIfChanged(ref _viewModel, value);
    }

    /// <inheritdoc/>
    public void SetItem(Model.Item item)
    {
        var candidateItemViewModel = _candidateItemViewModelBuilder.Build(item);
        ViewModel = candidateItemViewModel;
    }

    /// <summary>
    /// Construct by providing item model.
    /// </summary>
    /// <param name="item">Item model to be rendered.</param>
    /// <param name="candidateItemViewModelBuilder">Candidate item view model builder.</param>
    public CandidateItemContainerViewModel(Model.Item item,
        ICandidateItemViewModelBuilder candidateItemViewModelBuilder)
    {
        _candidateItemViewModelBuilder = candidateItemViewModelBuilder;

        // Bind inner ChooseCommand to outer ChooseCommand
        this.WhenAnyValue(x => x.ViewModel)
            .Where(vm => vm != null)
            .Select(vm => vm!.ChooseCommand)
            .Switch()
            .InvokeCommand(ChooseCommand);

        SetItem(item);
    }

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using Nymph.Model;
using Nymph.Shared.CandidateItem;
using ReactiveUI;

namespace Nymph.Shared.Group.ListUnfold;

/// <inheritdoc cref="IListUnfoldViewModel{TItem}" />
public class ListUnfoldViewModel<TItem> : ReactiveObject, IListUnfoldViewModel<TItem>
    where TItem : Item
{
    private readonly SourceList<ICandidateItemViewModel<Item>> _candidateItems = new();

    /// <summary>
    ///     Construct a new instance of <see cref="ListUnfoldViewModel{TItem}" />.
    /// </summary>
    /// <param name="candidateItemViewModelBuilder">Candidate item view model builder.</param>
    /// <param name="group">List unfold group.</param>
    public ListUnfoldViewModel(CandidateItemViewModelBuilder candidateItemViewModelBuilder, Model.Group.ListUnfold<TItem> group)
    {
        Group = group;

        _candidateItems.AddRange(group.List.Items.Select(candidateItemViewModelBuilder.Build));
        _candidateItems
            .Connect()
            .Bind(out var candidateItemViewModels)
            .Subscribe();
        CandidateItemViewModels = candidateItemViewModels;

        ChooseItemCommand = ReactiveCommand.CreateFromObservable(() =>
            _candidateItems
                .Connect()
                .AutoRefresh()
                .MergeMany(candidate => candidate.ChooseCommand.Select(_ => candidate.Item)));
    }

    /// <inheritdoc />
    public Model.Group.ListUnfold<TItem> Group { get; }

    /// <inheritdoc />
    public ReactiveCommand<Unit, Item> ChooseItemCommand { get; }

    /// <inheritdoc />
    public ReadOnlyObservableCollection<ICandidateItemViewModel<Item>> CandidateItemViewModels { get; }
}
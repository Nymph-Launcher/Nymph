using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using Nymph.Model;
using Nymph.Shared.CandidateItem;
using ReactiveUI;
using RenderedPreview = Nymph.Shared.ItemPreview;

namespace Nymph.Shared.Group.ItemPreview;

/// <inheritdoc cref="IItemPreviewViewModel{TItem}" />
public class ItemPreviewViewModel<TItem> : ReactiveObject, IItemPreviewViewModel<TItem> where TItem : Item
{
    private readonly SourceList<ICandidateItemViewModel<Item>> _candidateItemViewModels = new();

    /// <summary>
    ///     Construct a new instance of <see cref="ItemPreviewViewModel{TItem}" />.
    /// </summary>
    /// <param name="itemPreviewViewModelBuilder">Builder for item preview view model.</param>
    /// <param name="candidateItemViewModelBuilder">Builder for candidate item view model.</param>
    /// <param name="group">Item preview group.</param>
    public ItemPreviewViewModel(RenderedPreview.IItemPreviewViewModelBuilder itemPreviewViewModelBuilder,
        ICandidateItemViewModelBuilder candidateItemViewModelBuilder, Model.Group.ItemPreview<TItem> group)
    {
        Group = group;

        _candidateItemViewModels.Add(candidateItemViewModelBuilder.Build(new Item.Unit()));
        _candidateItemViewModels
            .Connect()
            .Bind(out var candidateItemViewModels)
            .Subscribe();
        CandidateItemViewModels = candidateItemViewModels;

        ChooseItemCommand = ReactiveCommand.CreateFromObservable(() =>
            _candidateItemViewModels
                .Connect()
                .AutoRefresh()
                .MergeMany(candidate => candidate.ChooseCommand.Select(_ => candidate.Item)));

        RenderedPreviewViewModel = itemPreviewViewModelBuilder.Build(group.Item);
    }

    /// <summary>
    ///     Inner item preview view model.
    /// </summary>
    public RenderedPreview.IItemPreviewViewModel<Item> RenderedPreviewViewModel { get; }

    /// <inheritdoc />
    public Model.Group.ItemPreview<TItem> Group { get; }

    /// <inheritdoc />
    public ReactiveCommand<Unit, Item> ChooseItemCommand { get; }

    /// <inheritdoc />
    public ReadOnlyObservableCollection<ICandidateItemViewModel<Item>> CandidateItemViewModels { get; }
}
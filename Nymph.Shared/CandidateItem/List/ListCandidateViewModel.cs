using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.List;

/// <inheritdoc cref="IListCandidateViewModel{TItem}"/>
/// <param name="item">List item.</param>
public class ListCandidateViewModel<TItem>(Item.List<TItem> item)
    : ReactiveObject, IListCandidateViewModel<TItem>
    where TItem : Item
{
    public Item.List<TItem> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand { get; }
}
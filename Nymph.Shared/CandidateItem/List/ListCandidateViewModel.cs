using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.List;

/// <summary>
/// Implementation of <see cref="IListCandidateViewModel{TItem}"/> for <see cref="Item.List{TItem}"/>.
/// </summary>
/// <param name="item">List item.</param>
/// <typeparam name="TItem">Type of the list items.</typeparam>
public class ListCandidateViewModel<TItem>(Item.List<TItem> item)
    : ReactiveObject, IListCandidateViewModel<TItem>
    where TItem : Item
{
    public Item.List<TItem> Item { get; } = item;
}
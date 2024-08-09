using System.Reactive;
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.List;

/// <summary>
/// Default constraint view model for list item.
/// </summary>
/// <typeparam name="TItem">Type of the item in the list.</typeparam>
public interface IListConstraintViewModel<TItem> : IConstraintItemViewModel<Item.List<TItem>> where TItem : Item
{
}

/// <inheritdoc cref="IListConstraintViewModel{TItem}"/>
/// <typeparam name="TItem"></typeparam>
public class ListConstraintViewModel<TItem>(Item.List<TItem> item) : ReactiveObject, IListConstraintViewModel<TItem>
    where TItem : Item
{
    public Item.List<TItem> Item { get; } = item;

    public ReactiveCommand<Unit, Unit> ClearCommand => ReactiveCommand.Create(() => { });
}
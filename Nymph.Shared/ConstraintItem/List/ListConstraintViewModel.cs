using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.List;

/// <inheritdoc cref="IListConstraintViewModel{TItem}" />
/// <param name="item">List item.</param>
public class ListConstraintViewModel<TItem>(Item.List<TItem> item) : ReactiveObject, IListConstraintViewModel<TItem>
    where TItem : Item
{
    public Item.List<TItem> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });
}
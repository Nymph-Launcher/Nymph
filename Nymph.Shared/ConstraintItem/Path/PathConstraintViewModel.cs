using System.Reactive;
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.Path;

/// <inheritdoc cref="IPathConstraintViewModel{TDecorator,TValue}"/>
/// <param name="item">Path item.</param>
public class PathConstraintViewModel<TDecorator, TValue>(Item.Path<TDecorator, TValue> item)
    : ReactiveObject, IPathConstraintViewModel<TDecorator, TValue>
    where TDecorator : Item
    where TValue : Item
{
    public Item.Path<TDecorator, TValue> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });
}
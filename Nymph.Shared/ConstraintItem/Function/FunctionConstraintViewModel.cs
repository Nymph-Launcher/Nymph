using System.Reactive;
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.Function;

/// <inheritdoc cref="IFunctionConstraintViewModel{TParam,TResult}"/>
/// <param name="item">Function item.</param>
public class FunctionConstraintViewModel<TParam, TResult>(Item.Function<TParam, TResult> item)
    : ReactiveObject, IFunctionConstraintViewModel<TParam, TResult>
    where TParam : Item
    where TResult : Item
{
    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });

    public Item.Function<TParam, TResult> Item { get; } = item;
}
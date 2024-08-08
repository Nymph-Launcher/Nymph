using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Function;

/// <inheritdoc cref="IFunctionCandidateViewModel{TParam,TResult}"/>
/// <param name="item">Function item.</param>
public class FunctionCandidateViewModel<TParam, TResult>(Item.Function<TParam, TResult> item)
    : ReactiveObject, IFunctionCandidateViewModel<TParam, TResult>
    where TParam : Item
    where TResult : Item
{
    public Item.Function<TParam, TResult> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
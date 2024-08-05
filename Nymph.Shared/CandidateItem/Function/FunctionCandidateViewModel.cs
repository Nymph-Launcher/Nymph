using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Function;

/// <summary>
/// Implementation of the default candidate view model for function item.
/// </summary>
/// <param name="item">Function item.</param>
/// <typeparam name="TParam">Type of the parameter of function item.</typeparam>
/// <typeparam name="TResult">Type of the result of function item.</typeparam>
public class FunctionCandidateViewModel<TParam, TResult>(Item.Function<TParam, TResult> item)
    : ReactiveObject, IFunctionCandidateViewModel<TParam, TResult>
    where TParam : Item
    where TResult : Item
{
    public Item.Function<TParam, TResult> Item { get; } = item;
}
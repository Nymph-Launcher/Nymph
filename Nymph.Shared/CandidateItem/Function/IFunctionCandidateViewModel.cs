using Nymph.Model;

namespace Nymph.Shared.CandidateItem.Function;

/// <summary>
///     Default candidate view model for function item.
/// </summary>
/// <typeparam name="TParam">Type of the param item.</typeparam>
/// <typeparam name="TResult">Type of the result item.</typeparam>
public interface
    IFunctionCandidateViewModel<TParam, TResult> : ICandidateItemViewModel<Item.Function<TParam, TResult>>
    where TParam : Item where TResult : Item
{
}
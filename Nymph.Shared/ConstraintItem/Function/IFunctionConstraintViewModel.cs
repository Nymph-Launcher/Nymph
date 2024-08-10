using Nymph.Model;

namespace Nymph.Shared.ConstraintItem.Function;

/// <summary>
/// Default view model for function constraint item.
/// </summary>
/// <typeparam name="TParam">Type of the function param item.</typeparam>
/// <typeparam name="TResult">Type of the function result item.</typeparam>
public interface
    IFunctionConstraintViewModel<TParam, TResult> : IConstraintItemViewModel<Item.Function<TParam, TResult>>
    where TParam : Item where TResult : Item
{
}
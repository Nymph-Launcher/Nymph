using Nymph.Model;

namespace Nymph.Shared.ItemPreview.Function;

/// <summary>
///     Default preview view model for function items.
/// </summary>
/// <typeparam name="TParam">Type of function param.</typeparam>
/// <typeparam name="TResult">Type of result param.</typeparam>
public interface IFunctionPreviewViewModel<TParam, TResult> : IItemPreviewViewModel<Item.Function<TParam, TResult>>
    where TParam : Item where TResult : Item
{
}
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.Function;

/// <inheritdoc cref="IFunctionPreviewViewModel{TParam,TResult}" />
/// <param name="item">Function item.</param>
public class FunctionPreviewViewModel<TParam, TResult>(Item.Function<TParam, TResult> item)
    : ReactiveObject, IFunctionPreviewViewModel<TParam, TResult>
    where TParam : Item
    where TResult : Item
{
    public Item.Function<TParam, TResult> Item { get; } = item;
}
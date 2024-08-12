using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.Path;

/// <inheritdoc cref="IPathPreviewViewModel{TDecorator,TValue}" />
/// <param name="item">Path item.</param>
public class PathPreviewViewModel<TDecorator, TValue>(Item.Path<TDecorator, TValue> item)
    : ReactiveObject, IPathPreviewViewModel<TDecorator, TValue>
    where TDecorator : Item
    where TValue : Item
{
    public Item.Path<TDecorator, TValue> Item { get; } = item;
}
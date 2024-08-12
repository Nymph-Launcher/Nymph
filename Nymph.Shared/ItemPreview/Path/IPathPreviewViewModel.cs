using Nymph.Model;

namespace Nymph.Shared.ItemPreview.Path;

/// <summary>
///     Default preview view model for path items.
/// </summary>
public interface IPathPreviewViewModel<TDecorator, TValue> : IItemPreviewViewModel<Item.Path<TDecorator, TValue>>
    where TDecorator : Item where TValue : Item
{
}
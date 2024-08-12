using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.List;

/// <inheritdoc cref="IListPreviewViewModel{TItem}" />
/// <param name="item">List item.</param>
public class ListPreviewViewModel<TItem>(Item.List<TItem> item) : ReactiveObject, IListPreviewViewModel<TItem>
    where TItem : Item
{
    public Item.List<TItem> Item { get; } = item;
}
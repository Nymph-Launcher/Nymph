using Nymph.Model;

namespace Nymph.Shared.ItemPreview.List;

/// <summary>
///     Default preview view model for list item.
/// </summary>
/// <typeparam name="TItem">Type of the items.</typeparam>
public interface IListPreviewViewModel<TItem> : IItemPreviewViewModel<Item.List<TItem>> where TItem : Item
{
}
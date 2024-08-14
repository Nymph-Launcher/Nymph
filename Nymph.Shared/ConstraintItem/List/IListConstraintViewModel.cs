using Nymph.Model;

namespace Nymph.Shared.ConstraintItem.List;

/// <summary>
///     Default constraint view model for list item.
/// </summary>
/// <typeparam name="TItem">Type of the item in the list.</typeparam>
public interface IListConstraintViewModel<TItem> : IConstraintItemViewModel<Item.List<TItem>> where TItem : Item
{
}
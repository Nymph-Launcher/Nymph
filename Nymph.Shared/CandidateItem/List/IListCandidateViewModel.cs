using Nymph.Model;

namespace Nymph.Shared.CandidateItem.List;

/// <summary>
///     Default candidate view model for list item.
/// </summary>
/// <typeparam name="TItem">Type of the items inside the list.</typeparam>
public interface IListCandidateViewModel<TItem> : ICandidateItemViewModel<Item.List<TItem>> where TItem : Item
{
}
using Nymph.Model;

namespace Nymph.Shared.Group.ListUnfold;

/// <summary>
///     Default view model for list unfold group.
/// </summary>
/// <typeparam name="TItem">Type of list item.</typeparam>
public interface IListUnfoldViewModel<TItem> : IGroupViewModel<Model.Group.ListUnfold<TItem>> where TItem : Item
{
}
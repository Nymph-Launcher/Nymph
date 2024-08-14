using Nymph.Model;

namespace Nymph.Shared.Group.ItemPreview;

/// <summary>
///     Default view model for item preview group.
/// </summary>
/// <typeparam name="TItem">Type of the previewed item.</typeparam>
public interface IItemPreviewViewModel<TItem> : IGroupViewModel<Model.Group.ItemPreview<TItem>> where TItem : Item
{
}
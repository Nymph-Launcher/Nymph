using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview;

/// <summary>
///     Item preview view mode.
/// </summary>
/// <typeparam name="TItem">Type of previewed item.</typeparam>
public interface IItemPreviewViewModel<out TItem> : IReactiveObject where TItem : Item
{
    /// <summary>
    ///     Item to be previewed.
    /// </summary>
    TItem Item { get; }
}
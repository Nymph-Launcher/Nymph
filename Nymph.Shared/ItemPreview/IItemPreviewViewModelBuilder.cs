using Nymph.Model;

namespace Nymph.Shared.ItemPreview;

/// <summary>
///     Builder for building item preview view model.
/// </summary>
public interface IItemPreviewViewModelBuilder
{
    /// <summary>
    ///     Build item preview view model.
    /// </summary>
    /// <param name="item">Item model to be previewed.</param>
    /// <returns>Item preview view model.</returns>
    /// <exception cref="InvalidOperationException">Fail to build item preview view model.</exception>
    IItemPreviewViewModel<Item> Build(Item item);
}
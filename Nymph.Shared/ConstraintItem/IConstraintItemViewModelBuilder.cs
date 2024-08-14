using Nymph.Model;

namespace Nymph.Shared.ConstraintItem;

/// <summary>
///     Builder for building constraint item view models.
/// </summary>
public interface IConstraintItemViewModelBuilder
{
    /// <summary>
    ///     Build constraint item view models from corresponding items.
    /// </summary>
    /// <param name="item">Item to be built from.</param>
    /// <returns>Built constraint item view model.</returns>
    /// <exception cref="InvalidOperationException">Fail to build candidate item view model.</exception>
    IConstraintItemViewModel<Item> Build(Item item);
}
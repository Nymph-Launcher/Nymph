using Nymph.Model;

namespace Nymph.Shared.CandidateItem;

public interface ICandidateItemViewModelBuilder
{
    /// <summary>
    /// Build candidate item view models from corresponding items.
    /// </summary>
    /// <param name="item">Item to be built from.</param>
    /// <returns>Built candidate item view model.</returns>
    /// <exception cref="InvalidOperationException">Fail to build the view model.</exception>
    ICandidateItemViewModel<Item> Build(Item item);
}
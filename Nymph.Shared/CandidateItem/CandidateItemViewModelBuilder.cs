using Autofac;
using Nymph.Model;

namespace Nymph.Shared.CandidateItem;

/// <summary>
/// Builder for building candidate item view models from corresponding items.
/// </summary>
/// <param name="componentContext">Container for resolving candidate view models.</param>
public class CandidateItemViewModelBuilder(IComponentContext componentContext)
{
    /// <summary>
    /// Build candidate item view models from corresponding items.
    /// </summary>
    /// <param name="item">Item to be built from.</param>
    /// <returns>Built candidate item view model.</returns>
    /// <exception cref="InvalidOperationException">Fail to build the view model.</exception>
    public ICandidateItemViewModel<Item> Build(Item item)
    {
        var itemType = item.GetType();
        var viewModelType = typeof(ICandidateItemViewModel<>).MakeGenericType(itemType);
        var viewModel = componentContext.Resolve(viewModelType, new TypedParameter(itemType, item));
        return viewModel as ICandidateItemViewModel<Item> ?? throw new InvalidOperationException();
    }
}
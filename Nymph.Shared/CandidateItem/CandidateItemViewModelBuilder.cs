using Autofac;
using Nymph.Model;

namespace Nymph.Shared.CandidateItem;

/// <inheritdoc />
/// <param name="componentContext">Container for resolving candidate view models.</param>
public class CandidateItemViewModelBuilder(IComponentContext componentContext) : ICandidateItemViewModelBuilder
{
    /// <inheritdoc />
    public ICandidateItemViewModel<Item> Build(Item item)
    {
        var itemType = item.GetType();
        var viewModelType = typeof(ICandidateItemViewModel<>).MakeGenericType(itemType);
        var viewModel = componentContext.Resolve(viewModelType, new TypedParameter(itemType, item));
        return viewModel as ICandidateItemViewModel<Item> ?? throw new InvalidOperationException();
    }
}
using Autofac;
using Nymph.Model;

namespace Nymph.Shared.ConstraintItem;

/// <inheritdoc />
/// <param name="componentContext">Container for resolving constraint item view models.</param>
public class ConstraintItemViewModelBuilder(IComponentContext componentContext) : IConstraintItemViewModelBuilder
{
    /// <inheritdoc />
    public IConstraintItemViewModel<Item> Build(Item item)
    {
        var itemType = item.GetType();
        var viewModelType = typeof(IConstraintItemViewModel<>).MakeGenericType(itemType);
        var viewModel = componentContext.Resolve(viewModelType, new TypedParameter(itemType, item));
        return viewModel as IConstraintItemViewModel<Item> ?? throw new InvalidOperationException();
    }
}
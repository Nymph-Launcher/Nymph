using Autofac;
using Nymph.Model;

namespace Nymph.Shared.ItemPreview;

/// <inheritdoc />
/// <param name="componentContext">Container to resolve view model from.</param>
public class ItemPreviewViewModelBuilder(IComponentContext componentContext) : IItemPreviewViewModelBuilder
{
    public IItemPreviewViewModel<Item> Build(Item item)
    {
        var itemType = item.GetType();
        var viewModelType = typeof(IItemPreviewViewModel<>).MakeGenericType(itemType);
        var viewModel = componentContext.Resolve(viewModelType, new TypedParameter(itemType, item));
        return viewModel as IItemPreviewViewModel<Item> ?? throw new InvalidOperationException();
    }
}
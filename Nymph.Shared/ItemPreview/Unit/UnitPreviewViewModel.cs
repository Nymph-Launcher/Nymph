using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.Unit;

/// <inheritdoc cref="IUnitPreviewViewModel" />
/// <param name="item">Unit item.</param>
public class UnitPreviewViewModel(Item.Unit item) : ReactiveObject, IUnitPreviewViewModel
{
    public Item.Unit Item { get; } = item;
}
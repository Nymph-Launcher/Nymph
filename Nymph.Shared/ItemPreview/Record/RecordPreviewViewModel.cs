using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.Record;

/// <inheritdoc cref="IRecordPreviewViewModel" />
/// <param name="item">Record item.</param>
public class RecordPreviewViewModel(Item.Record item) : ReactiveObject, IRecordPreviewViewModel
{
    public Item.Record Item { get; } = item;
}
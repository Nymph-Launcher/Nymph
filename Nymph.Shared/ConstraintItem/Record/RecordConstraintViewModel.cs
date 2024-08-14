using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.Record;

/// <inheritdoc cref="IRecordConstraintViewModel" />
/// <param name="item">Record item.</param>
public class RecordConstraintViewModel(Item.Record item) : ReactiveObject, IRecordConstraintViewModel
{
    public Item.Record Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });
}
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Record;

/// <inheritdoc cref="IRecordCandidateViewModel"/>
/// <param name="item">Record item.</param>
public class RecordCandidateViewModel(Item.Record item) : ReactiveObject, IRecordCandidateViewModel
{
    public Item.Record Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
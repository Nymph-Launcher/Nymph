using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Record;

/// <summary>
/// Implementation of <see cref="IRecordCandidateViewModel"/> for <see cref="Item.Record"/>.
/// </summary>
/// <param name="item">Record item.</param>
public class RecordCandidateViewModel(Item.Record item) : ReactiveObject, IRecordCandidateViewModel
{
    public Item.Record Item { get; } = item;
}
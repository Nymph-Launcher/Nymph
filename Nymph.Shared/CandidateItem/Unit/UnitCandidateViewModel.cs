using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Unit;

public class UnitCandidateViewModel(Item.Unit item) : ReactiveObject, IUnitCandidateViewModel
{
    public Item.Unit Item { get; } = item;
}
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Unit;

/// <inheritdoc cref="IUnitCandidateViewModel"/>
/// <param name="item">Unit item.</param>
public class UnitCandidateViewModel(Item.Unit item) : ReactiveObject, IUnitCandidateViewModel
{
    public Item.Unit Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
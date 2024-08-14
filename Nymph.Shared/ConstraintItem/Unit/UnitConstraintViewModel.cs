using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.Unit;

/// <inheritdoc cref="IUnitConstraintViewModel" />
/// <param name="item">Unit item.</param>
public class UnitConstraintViewModel(Item.Unit item) : ReactiveObject, IUnitConstraintViewModel
{
    public Item.Unit Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });
}
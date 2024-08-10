using System.Reactive;
using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ConstraintItem.Atom;

/// <inheritdoc cref="IAtomConstraintViewModel{TValue}"/>
/// <param name="item">Atom item.</param>
public class AtomConstraintViewModel<TValue>(Item.Atom<TValue> item) : ReactiveObject, IAtomConstraintViewModel<TValue>
{
    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ClearCommand =>
        ReactiveCommand.Create(() => { });

    public Item.Atom<TValue> Item { get; } = item;
}
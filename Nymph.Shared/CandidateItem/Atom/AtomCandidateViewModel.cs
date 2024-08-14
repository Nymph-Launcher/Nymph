using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Atom;

/// <inheritdoc cref="IAtomCandidateViewModel{TValue}" />
/// <param name="item">Atom item.</param>
public class AtomCandidateViewModel<TValue>(Item.Atom<TValue> item) : ReactiveObject, IAtomCandidateViewModel<TValue>
{
    public Item.Atom<TValue> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
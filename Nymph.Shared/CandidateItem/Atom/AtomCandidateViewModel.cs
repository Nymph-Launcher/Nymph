using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Atom;

/// <summary>
/// Implementation of <see cref="IAtomCandidateViewModel{TValue}"/> for <see cref="Item.Atom{TValue}"/>.
/// </summary>
/// <param name="item">Atom item.</param>
/// <typeparam name="TValue">Type of the value inside atom item.</typeparam>
public class AtomCandidateViewModel<TValue>(Item.Atom<TValue> item) : ReactiveObject, IAtomCandidateViewModel<TValue>
{
    public Item.Atom<TValue> Item { get; } = item;
}
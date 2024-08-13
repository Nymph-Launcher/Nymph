using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.ItemPreview.Atom;

/// <inheritdoc cref="IAtomPreviewViewModel{TValue}" />
/// <param name="item">Atom item.</param>
public class AtomPreviewViewModel<TValue>(Item.Atom<TValue> item) : ReactiveObject, IAtomPreviewViewModel<TValue>
{
    public Item.Atom<TValue> Item { get; } = item;
}
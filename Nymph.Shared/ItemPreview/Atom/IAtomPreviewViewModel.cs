using Nymph.Model;

namespace Nymph.Shared.ItemPreview.Atom;

/// <summary>
///     Default preview view model for atom items.
/// </summary>
public interface IAtomPreviewViewModel<TValue> : IItemPreviewViewModel<Item.Atom<TValue>>
{
}
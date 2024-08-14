using Nymph.Model;

namespace Nymph.Shared.ConstraintItem.Atom;

/// <summary>
///     Default constraint view model for atom item.
/// </summary>
/// <typeparam name="TValue">Type of the atom item value.</typeparam>
public interface IAtomConstraintViewModel<TValue> : IConstraintItemViewModel<Item.Atom<TValue>>
{
}
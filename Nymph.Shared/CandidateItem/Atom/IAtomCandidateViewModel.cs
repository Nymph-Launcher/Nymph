﻿using Nymph.Model;

namespace Nymph.Shared.CandidateItem.Atom;

/// <summary>
///     Default candidate view model for atom item.
/// </summary>
/// <typeparam name="TValue">Type of the value inside atom item.</typeparam>
public interface IAtomCandidateViewModel<TValue> : ICandidateItemViewModel<Item.Atom<TValue>>
{
}
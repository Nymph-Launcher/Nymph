using Nymph.Model;

namespace Nymph.Shared.CandidateItem.Path;

/// <summary>
/// Default candidate view model for path item.
/// </summary>
/// <typeparam name="TDecorator">Type of decorator of path item.</typeparam>
/// <typeparam name="TValue">Type of value of path item.</typeparam>
public interface IPathCandidateViewModel<TDecorator, TValue> : ICandidateItemViewModel<Item.Path<TDecorator, TValue>>
    where TDecorator : Item where TValue : Item
{
}
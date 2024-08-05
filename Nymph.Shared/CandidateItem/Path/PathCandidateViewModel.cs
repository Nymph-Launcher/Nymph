using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Path;

/// <summary>
/// Implementation of <see cref="IPathCandidateViewModel{TDecorator, TValue}"/> for <see cref="Item.Path{TDecorator, TValue}"/>.
/// </summary>
/// <param name="item">Path item.</param>
/// <typeparam name="TDecorator">Type of the decorator of the item.</typeparam>
/// <typeparam name="TValue">Type of the value of the item.</typeparam>
public class PathCandidateViewModel<TDecorator, TValue>(Item.Path<TDecorator, TValue> item)
    : ReactiveObject, IPathCandidateViewModel<TDecorator, TValue>
    where TDecorator : Item
    where TValue : Item
{
    public Item.Path<TDecorator, TValue> Item { get; } = item;
}
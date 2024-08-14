using Nymph.Model;
using ReactiveUI;

namespace Nymph.Shared.CandidateItem.Path;

/// <inheritdoc cref="IPathCandidateViewModel{TDecorator,TValue}" />
/// <param name="item">Path item.</param>
public class PathCandidateViewModel<TDecorator, TValue>(Item.Path<TDecorator, TValue> item)
    : ReactiveObject, IPathCandidateViewModel<TDecorator, TValue>
    where TDecorator : Item
    where TValue : Item
{
    public Item.Path<TDecorator, TValue> Item { get; } = item;

    public ReactiveCommand<System.Reactive.Unit, System.Reactive.Unit> ChooseCommand =>
        ReactiveCommand.Create(() => { });
}
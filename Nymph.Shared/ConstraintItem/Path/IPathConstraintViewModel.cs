using Nymph.Model;

namespace Nymph.Shared.ConstraintItem.Path;

/// <summary>
///     Default constraint view model for path item.
/// </summary>
/// <typeparam name="TDecorator">Decorator type of the path item.</typeparam>
/// <typeparam name="TValue">Decorator type of the path item.</typeparam>
public interface IPathConstraintViewModel<TDecorator, TValue> : IConstraintItemViewModel<Item.Path<TDecorator, TValue>>
    where TDecorator : Item where TValue : Item
{
}
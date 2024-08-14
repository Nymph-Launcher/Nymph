using Nymph.Model;
using ReactiveUI;
using ReactiveUnit = System.Reactive.Unit;

namespace Nymph.Shared.ConstraintItem;

/// <summary>
///     Constraint item view model that is bound to a specific item.
/// </summary>
/// <typeparam name="TItem">Type of the item.</typeparam>
public interface IConstraintItemViewModel<out TItem> : IReactiveObject where TItem : Item
{
    /// <summary>
    ///     Item that the view model is bound to.
    /// </summary>
    TItem Item { get; }

    /// <summary>
    ///     Clear the constraint item.
    /// </summary>
    ReactiveCommand<ReactiveUnit, ReactiveUnit> ClearCommand { get; }
}
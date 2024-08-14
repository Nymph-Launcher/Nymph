using System.Collections.ObjectModel;
using System.Reactive;
using Nymph.Model;
using Nymph.Shared.CandidateItem;
using ReactiveUI;

namespace Nymph.Shared.Group;

/// <summary>
///     View model for item group.
/// </summary>
/// <typeparam name="TGroup"></typeparam>
public interface IGroupViewModel<out TGroup> : IReactiveObject where TGroup : Model.Group
{
    /// <summary>
    ///     Item group.
    /// </summary>
    TGroup Group { get; }

    /// <summary>
    ///     Command to choose the item.
    /// </summary>
    ReactiveCommand<Unit, Item> ChooseItemCommand { get; }

    /// <summary>
    ///     Readonly collection of items.
    /// </summary>
    ReadOnlyObservableCollection<ICandidateItemViewModel<Item>> CandidateItemViewModels { get; }
}
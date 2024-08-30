namespace Nymph.Model.Strategy;

/// <summary>
///     Represents an item with tracking information.
/// </summary>
/// <param name="Item">Item.</param>
/// <param name="MiddlewarePipeline">Middlewares applied.</param>
public record TrackableItem(Item Item, Seq<IStrategyMiddleware> MiddlewarePipeline = default)
{
    /// <summary>
    ///     Creates a new instance of <see cref="TrackableItem" /> from an <see cref="Item" />.
    /// </summary>
    /// <param name="item">Item.</param>
    /// <returns>Trackable item.</returns>
    public static TrackableItem FromItem(Item item)
    {
        return new TrackableItem(item);
    }
}

/// <summary>
///     Represents an item with tracking information.
/// </summary>
/// <param name="Item">Item.</param>
/// <param name="MiddlewarePipeline">Middlewares applied.</param>
/// <typeparam name="TItem">Item type.</typeparam>
public record TrackableItem<TItem>(TItem Item, Seq<IStrategyMiddleware> MiddlewarePipeline = default)
    where TItem : Item
{
    /// <summary>
    ///     Creates a new instance of <see cref="TrackableItem{TItem}" /> from an <see cref="Item" />.
    /// </summary>
    /// <param name="item">Item.</param>
    /// <returns>Trackable item.</returns>
    public static TrackableItem<TItem> FromItem(TItem item)
    {
        return new TrackableItem<TItem>(item);
    }
}
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

    /// <summary>
    ///     Adds a middleware to the pipeline.
    /// </summary>
    /// <param name="middleware">Middleware added.</param>
    /// <returns>Trackable item.</returns>
    public TrackableItem AddMiddleware(IStrategyMiddleware middleware)
    {
        return this with { MiddlewarePipeline = MiddlewarePipeline.Add(middleware) };
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

    /// <summary>
    ///     Implicitly converts a <see cref="TrackableItem{TItem}" /> to a <see cref="TrackableItem" />.
    /// </summary>
    /// <param name="trackableItem">Generic trackable item.</param>
    /// <returns>Trackable item.</returns>
    public static implicit operator TrackableItem(TrackableItem<TItem> trackableItem)
    {
        return new TrackableItem(trackableItem.Item, trackableItem.MiddlewarePipeline);
    }

    /// <summary>
    ///     Adds a middleware to the pipeline.
    /// </summary>
    /// <param name="middleware">Middleware added.</param>
    /// <returns>Trackable item.</returns>
    public TrackableItem<TItem> AddMiddleware(IStrategyMiddleware middleware)
    {
        return this with { MiddlewarePipeline = MiddlewarePipeline.Add(middleware) };
    }
}
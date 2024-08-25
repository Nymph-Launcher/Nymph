namespace Nymph.Model;

/// <summary>
///     Representation of a group of items that can have transient state.
/// </summary>
public abstract record Group
{
    /// <summary>
    ///     Group for previewing an item.
    /// </summary>
    /// <param name="Item">Item to be previewed.</param>
    /// <typeparam name="TItem">Type of the previewed item.</typeparam>
    public record ItemPreview<TItem>(TItem Item) : Group where TItem : Item;

    /// <summary>
    ///     Group for unfolding a list of items.
    /// </summary>
    /// <param name="List">List item to be unfolded.</param>
    /// <typeparam name="TItem">Type of the items of the list.</typeparam>
    public record ListUnfold<TItem>(Item.List<TItem> List) : Group where TItem : Item;

    /// <summary>
    ///     Group for unfolding a record item.
    /// </summary>
    /// <param name="Record">Record item to be unfolded.</param>
    public record RecordUnfold(Item.Record Record) : Group;

    /// <summary>
    ///     Group for unfolding a path item.
    /// </summary>
    /// <param name="Path">Path item to be unfolded.</param>
    /// <typeparam name="TDecorator">Type of the decorator item.</typeparam>
    /// <typeparam name="TValue">Type of the value item.</typeparam>
    public record PathUnfold<TDecorator, TValue>(Item.Path<TDecorator, TValue> Path)
        : Group where TDecorator : Item where TValue : Item;

    /// <summary>
    ///     Group for executing a unary function item over a param item.
    /// </summary>
    /// <param name="Function">Unary function item.</param>
    /// <param name="Param">Parameter item.</param>
    /// <typeparam name="TParam">Type of the param.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record UnaryExecute<TParam, TResult>(Item.Function<TParam, TResult> Function, TParam Param)
        : Group where TParam : Item where TResult : Item;

    /// <summary>
    ///     Group for executing a binary function item over a param item and text item.
    /// </summary>
    /// <param name="Function">Binary function item.</param>
    /// <param name="Param">Parameter item.</param>
    /// <param name="Text">Text item.</param>
    /// <typeparam name="TParam">Type of the param.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record BinaryExecute<TParam, TResult>(
        Item.Function<TParam, Item.Function<Item.Atom<string>, TResult>> Function,
        TParam Param,
        Item.Atom<string> Text) : Group where TParam : Item where TResult : Item;
}
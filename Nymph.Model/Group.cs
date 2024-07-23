namespace Nymph.Model;

/// <summary>
/// Representation of a group of items that can have transient state.
/// </summary>
public abstract record Group
{
    /// <summary>
    /// Group for previewing an item.
    /// </summary>
    /// <param name="Item">Item to be previewed.</param>
    /// <typeparam name="TItem">Type of the previewed item.</typeparam>
    public record ItemPreview<TItem>(TItem Item) : Group where TItem : Item;
    
    /// <summary>
    /// Group for unfolding a list of items.
    /// </summary>
    /// <param name="List">List item to be unfolded.</param>
    /// <typeparam name="TItem">Type of the items of the list.</typeparam>
    public record ListUnfold<TItem>(Item.List<TItem> List) : Group where TItem : Item;

    /// <summary>
    /// Group for unfolding a record item.
    /// </summary>
    /// <param name="Record">Record item to be unfolded.</param>
    public record RecordUnfold(Item.Record Record) : Group;

    /// <summary>
    /// Group for statically execute a function over an item.
    /// </summary>
    /// <param name="Func">Function item to be executed.</param>
    /// <param name="Item">Param item to be executed over.</param>
    /// <typeparam name="TParam">Type of the param item.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record StaticExecution<TParam, TResult>(Item.Function<TParam, TResult> Func, TParam Item)
        : Group where TParam : Item where TResult : Item;

    /// <summary>
    /// Group for dynamically execute a function over the input text.
    /// </summary>
    /// <param name="Func">Function item to be executed.</param>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record DynamicExecution<TResult>(Item.Function<Item.Atom<string>, TResult> Func)
        : Group where TResult : Item;

    /// <summary>
    /// Group for binary execution of a function over an item and the input text.
    /// </summary>
    /// <param name="Func">Binary function item.</param>
    /// <param name="Item">Static item param.</param>
    /// <typeparam name="TParam">Type of the static item param.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record BinaryExecution<TParam, TResult>(
        Item.Function<TParam, Item.Function<Item.Atom<string>, TResult>> Func,
        TParam Item)
        : Group where TParam : Item where TResult : Item;
}
namespace Nymph.Model;

/// <summary>
///     Represents an item in the Nymph launcher.
/// </summary>
public abstract record Item
{
    /// <summary>
    ///     Item wrapper around a value.
    /// </summary>
    /// <param name="Value">Wrapped value.</param>
    /// <typeparam name="TValue">Type of the wrapped value.</typeparam>
    public record Atom<TValue>(TValue Value) : Item;

    /// <summary>
    ///     Item of a list of items.
    /// </summary>
    /// <param name="Items">Items.</param>
    /// <typeparam name="TItem">Type of the items.</typeparam>
    public record List<TItem>(Seq<TItem> Items) : Item where TItem : Item;

    /// <summary>
    ///     Unit item.
    /// </summary>
    public record Unit : Item;

    /// <summary>
    ///     Tagged tuple of items.
    /// </summary>
    /// <param name="Fields">Tagged items.</param>
    public record Record(Map<string, Item> Fields) : Item;

    /// <summary>
    ///     Item of a function over an item.
    /// </summary>
    /// <param name="Name">Name of the function item.</param>
    /// <param name="Execution">Execution function over a param item.</param>
    /// <param name="Validation">Validation predicate.</param>
    /// <param name="ShouldManual">Should the execution be manually triggered.</param>
    /// <typeparam name="TParam">Type of the parameter.</typeparam>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public record Function<TParam, TResult>(
        string Name,
        Func<TParam, Task<Seq<TResult>>> Execution,
        Option<Predicate<TParam>> Validation = default,
        bool ShouldManual = false)
        : Item where TParam : Item where TResult : Item;

    /// <summary>
    ///     Item of a decorated item.
    /// </summary>
    /// <param name="Value">Decorated item.</param>
    /// <param name="Decorator">Decorator item.</param>
    /// <typeparam name="TDecorator">Type of the decorator.</typeparam>
    /// <typeparam name="TValue">Type of the decorated value.</typeparam>
    public record Path<TDecorator, TValue>(TDecorator Decorator, TValue Value)
        : Item where TDecorator : Item where TValue : Item;
}
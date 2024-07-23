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
    public record ListPreview<TItem>(Seq<TItem> List) : Group where TItem : Item;
}
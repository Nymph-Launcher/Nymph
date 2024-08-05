namespace Nymph.Shared.ConstraintItem;

public interface IConstraintItemViewModel
{
}

public interface IConstraintItemViewModel<TItem> : IConstraintItemViewModel where TItem : Model.Item
{
}
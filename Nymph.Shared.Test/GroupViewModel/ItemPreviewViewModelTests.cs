using FluentAssertions;
using Nymph.Shared.Group;

namespace Nymph.Shared.Test.GroupViewModel;

public class ItemPreviewViewModelTests
{
    private readonly IContainer _container;

    public ItemPreviewViewModelTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void ItemPreviewViewModel_Emits_UnitItem()
    {
        var item = new Item.Atom<int>(10);

        var itemPreviewGroup = new Model.Group.ItemPreview<Item.Atom<int>>(item);

        var itemPreviewViewModel =
            _container.Resolve<IGroupViewModel<Model.Group.ItemPreview<Item.Atom<int>>>>(
                new TypedParameter(typeof(Model.Group.ItemPreview<Item.Atom<int>>), itemPreviewGroup));

        itemPreviewViewModel.CandidateItemViewModels[0].Item.Should().BeOfType(typeof(Item.Unit));
    }
}
using Nymph.Shared.Group;

namespace Nymph.Shared.Test.GroupViewModel;

public class ListUnfoldViewModelTests
{
    private readonly IContainer _container;

    public ListUnfoldViewModelTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void ListUnfoldViewModel_ReturnsExactListItems()
    {
        var listItem = new Item.List<Item.Atom<int>>(Seq(new Item.Atom<int>(1),
            new Item.Atom<int>(2), new Item.Atom<int>(3)));

        var listUnfoldGroup = new Model.Group.ListUnfold<Item.Atom<int>>(listItem);

        var listUnfoldViewModel =
            _container.Resolve<IGroupViewModel<Model.Group.ListUnfold<Item.Atom<int>>>>(
                new TypedParameter(typeof(Model.Group.ListUnfold<Item.Atom<int>>), listUnfoldGroup));

        Assert.Equal(listUnfoldViewModel.CandidateItemViewModels.Select(vm => vm.Item), listItem.Items);
    }
}
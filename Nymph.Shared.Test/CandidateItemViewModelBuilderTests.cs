using Nymph.Shared.CandidateItem;
using Nymph.Shared.CandidateItem.Atom;
using Nymph.Shared.CandidateItem.Function;
using Nymph.Shared.CandidateItem.List;
using Nymph.Shared.CandidateItem.Path;
using Nymph.Shared.CandidateItem.Record;
using Nymph.Shared.CandidateItem.Unit;

namespace Nymph.Shared.Test;

public class CandidateItemViewModelBuilderTests
{
    private readonly IContainer _container;

    public CandidateItemViewModelBuilderTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void Build_WhenItemIsAtom_ReturnsAtomCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Atom<int>(10);
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<AtomCandidateViewModel<int>>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }

    [Fact]
    public void Build_WhenItemIsList_ReturnsListCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.List<Item.Atom<int>>(Seq(new Item.Atom<int>(1),
            new Item.Atom<int>(2), new Item.Atom<int>(3)));
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<ListCandidateViewModel<Item.Atom<int>>>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }

    [Fact]
    public void Build_WhenItemIsFunction_ReturnsFunctionCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Function<Item.Atom<int>, Item.Atom<string>>("Display integer",
            number => new Item.Atom<string>($"Number is {number}"));
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<FunctionCandidateViewModel<Item.Atom<int>, Item.Atom<string>>>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }

    [Fact]
    public void Build_WhenItemIsPath_ReturnsPathCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Path<Item.Atom<int>, Item.Atom<string>>(new Item.Atom<int>(10),
            new Item.Atom<string>("10"));
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<PathCandidateViewModel<Item.Atom<int>, Item.Atom<string>>>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }

    [Fact]
    public void Build_WhenItemIsRecord_ReturnsRecordCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Record(Map<string, Item>(("name", new Item.Atom<string>("John")),
            ("age", new Item.Atom<int>(30))));
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<RecordCandidateViewModel>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }

    [Fact]
    public void Build_WhenItemIsUnit_ReturnsUnitCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Unit();
        var viewModel = builder.Build(item);

        Assert.Multiple(() =>
        {
            Assert.IsType<UnitCandidateViewModel>(viewModel);
            Assert.Equal(viewModel.Item, item);
        });
    }
}
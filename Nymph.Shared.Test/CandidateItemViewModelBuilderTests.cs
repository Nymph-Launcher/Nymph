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

        viewModel.Should().BeOfType<AtomCandidateViewModel<int>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsList_ReturnsListCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.List<Item.Atom<int>>(Seq(new Item.Atom<int>(1),
            new Item.Atom<int>(2), new Item.Atom<int>(3)));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<ListCandidateViewModel<Item.Atom<int>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsFunction_ReturnsFunctionCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Function<Item.Atom<int>, Item.Atom<string>>(new Item.FunctionSemantic("Display integer"),
            number => Task.FromResult(Seq([new Item.Atom<string>($"Number is {number}")])));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<FunctionCandidateViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsPath_ReturnsPathCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Path<Item.Atom<int>, Item.Atom<string>>(new Item.Atom<int>(10),
            new Item.Atom<string>("10"));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<PathCandidateViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsRecord_ReturnsRecordCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Record(Map<string, Item>(("name", new Item.Atom<string>("John")),
            ("age", new Item.Atom<int>(30))));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<RecordCandidateViewModel>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsUnit_ReturnsUnitCandidateViewModel()
    {
        var builder = _container.Resolve<ICandidateItemViewModelBuilder>();
        var item = new Item.Unit();
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<UnitCandidateViewModel>();
        viewModel.Item.Should().Be(item);
    }
}
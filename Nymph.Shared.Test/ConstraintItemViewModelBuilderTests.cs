using Nymph.Shared.ConstraintItem;
using Nymph.Shared.ConstraintItem.Atom;
using Nymph.Shared.ConstraintItem.Function;
using Nymph.Shared.ConstraintItem.List;
using Nymph.Shared.ConstraintItem.Path;
using Nymph.Shared.ConstraintItem.Record;
using Nymph.Shared.ConstraintItem.Unit;

namespace Nymph.Shared.Test;

public class ConstraintItemViewModelBuilderTests
{
    private readonly IContainer _container;

    public ConstraintItemViewModelBuilderTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void Build_WhenItemIsAtom_ReturnsAtomConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.Atom<int>(10);
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<AtomConstraintViewModel<int>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsList_ReturnsListConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.List<Item.Atom<int>>(Seq(new Item.Atom<int>(1),
            new Item.Atom<int>(2), new Item.Atom<int>(3)));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<ListConstraintViewModel<Item.Atom<int>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsFunction_ReturnsFunctionConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.Function<Item.Atom<int>, Item.Atom<string>>(new Item.FunctionSemantic("Display integer"),
            number => Task.FromResult(Seq([new Item.Atom<string>($"Number is {number}")])));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<FunctionConstraintViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsPath_ReturnsPathConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.Path<Item.Atom<int>, Item.Atom<string>>(new Item.Atom<int>(10),
            new Item.Atom<string>("10"));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<PathConstraintViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsRecord_ReturnsRecordConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.Record(Map<string, Item>(("name", new Item.Atom<string>("John")),
            ("age", new Item.Atom<int>(30))));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<RecordConstraintViewModel>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsUnit_ReturnsUnitConstraintViewModel()
    {
        var builder = _container.Resolve<IConstraintItemViewModelBuilder>();
        var item = new Item.Unit();
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<UnitConstraintViewModel>();
        viewModel.Item.Should().Be(item);
    }
}
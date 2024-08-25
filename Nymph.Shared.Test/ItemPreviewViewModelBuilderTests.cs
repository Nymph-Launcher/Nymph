using Nymph.Shared.ItemPreview;
using Nymph.Shared.ItemPreview.Atom;
using Nymph.Shared.ItemPreview.Function;
using Nymph.Shared.ItemPreview.List;
using Nymph.Shared.ItemPreview.Path;
using Nymph.Shared.ItemPreview.Record;
using Nymph.Shared.ItemPreview.Unit;

namespace Nymph.Shared.Test;

public class ItemPreviewViewModelBuilderTests
{
    private readonly IContainer _container;

    public ItemPreviewViewModelBuilderTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void Build_WhenItemIsAtom_ReturnsAtomPreviewViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.Atom<int>(10);
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<AtomPreviewViewModel<int>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsList_ReturnsListPreviewViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.List<Item.Atom<int>>(Seq(new Item.Atom<int>(1),
            new Item.Atom<int>(2), new Item.Atom<int>(3)));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<ListPreviewViewModel<Item.Atom<int>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsFunction_ReturnsFunctionPreviewViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.Function<Item.Atom<int>, Item.Atom<string>>(new Item.FunctionSemantic("Display integer"),
            number => Task.FromResult(Seq([new Item.Atom<string>($"Number is {number}")])));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<FunctionPreviewViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsPath_ReturnsPathPreviewViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.Path<Item.Atom<int>, Item.Atom<string>>(new Item.Atom<int>(10),
            new Item.Atom<string>("10"));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<PathPreviewViewModel<Item.Atom<int>, Item.Atom<string>>>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsRecord_ReturnsRecordPreviewViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.Record(Map<string, Item>(("name", new Item.Atom<string>("John")),
            ("age", new Item.Atom<int>(30))));
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<RecordPreviewViewModel>();
        viewModel.Item.Should().Be(item);
    }

    [Fact]
    public void Build_WhenItemIsUnit_ReturnsUnitConstraintViewModel()
    {
        var builder = _container.Resolve<IItemPreviewViewModelBuilder>();
        var item = new Item.Unit();
        var viewModel = builder.Build(item);

        viewModel.Should().BeOfType<UnitPreviewViewModel>();
        viewModel.Item.Should().Be(item);
    }
}
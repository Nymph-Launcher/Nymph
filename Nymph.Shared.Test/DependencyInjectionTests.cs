using Nymph.Shared.CandidateItem;
using Nymph.Shared.CandidateItem.Atom;
using Nymph.Shared.DependencyInjection;

namespace Nymph.Shared.Test;

public class DependencyInjectionTests
{
    private readonly IContainer _container;

    public DependencyInjectionTests()
    {
        var builder = new ContainerBuilder();

        builder.RegisterNymphShared();

        _container = builder.Build();
    }

    [Fact]
    public void CanResolveCandidateItemContainerViewModel()
    {
        var item = new Item.Atom<int>(10);

        var containerViewModel =
            _container.Resolve<ICandidateItemContainerViewModel>(new TypedParameter(typeof(Item), item));

        Assert.Multiple(() =>
        {
            Assert.IsType<AtomCandidateViewModel<int>>(containerViewModel.ViewModel);
            Assert.Equal(containerViewModel.ViewModel.Item, item);
        });
    }
}
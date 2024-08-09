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
}
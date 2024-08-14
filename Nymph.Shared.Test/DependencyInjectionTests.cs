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
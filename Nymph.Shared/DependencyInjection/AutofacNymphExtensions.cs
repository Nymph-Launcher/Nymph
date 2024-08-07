using Autofac;
using Nymph.Model;
using Nymph.Shared.CandidateItem;
using Nymph.Shared.CandidateItem.Atom;
using Nymph.Shared.CandidateItem.Function;
using Nymph.Shared.CandidateItem.List;
using Nymph.Shared.CandidateItem.Path;
using Nymph.Shared.CandidateItem.Record;
using Nymph.Shared.CandidateItem.Unit;

namespace Nymph.Shared.DependencyInjection;

public static class AutofacNymphExtensions
{
    public static void RegisterNymph(this ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(AtomCandidateViewModel<>))
            .As(typeof(ICandidateItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Atom<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(FunctionCandidateViewModel<,>))
            .As(typeof(ICandidateItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Function<,>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(ListCandidateViewModel<>))
            .As(typeof(ICandidateItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.List<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(PathCandidateViewModel<,>))
            .As(typeof(ICandidateItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Path<,>),
                (pi, _) => pi);
        
        builder.RegisterType(typeof(RecordCandidateViewModel))
            .As(typeof(ICandidateItemViewModel<Item.Record>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Record),
                (pi, _) => pi);

        builder.RegisterType(typeof(UnitCandidateViewModel))
            .As(typeof(ICandidateItemViewModel<Item.Unit>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Unit),
                (pi, _) => pi);

        builder.RegisterType<CandidateItemViewModelBuilder>()
            .As<ICandidateItemViewModelBuilder>();
    }
}
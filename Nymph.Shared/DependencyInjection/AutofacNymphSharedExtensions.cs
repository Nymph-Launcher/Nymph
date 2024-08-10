using Autofac;
using Nymph.Model;
using Nymph.Shared.CandidateItem;
using Nymph.Shared.CandidateItem.Atom;
using Nymph.Shared.CandidateItem.Function;
using Nymph.Shared.CandidateItem.List;
using Nymph.Shared.CandidateItem.Path;
using Nymph.Shared.CandidateItem.Record;
using Nymph.Shared.CandidateItem.Unit;
using Nymph.Shared.ConstraintItem;
using Nymph.Shared.ConstraintItem.Atom;
using Nymph.Shared.ConstraintItem.Function;
using Nymph.Shared.ConstraintItem.List;
using Nymph.Shared.ConstraintItem.Path;
using Nymph.Shared.ConstraintItem.Record;
using Nymph.Shared.ConstraintItem.Unit;

namespace Nymph.Shared.DependencyInjection;

public static class AutofacNymphSharedExtensions
{
    private static void RegisterCandidateItemViewModel(ContainerBuilder builder)
    {
        // Register candidate item view model
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

        // register candidate item view model builder
        builder.RegisterType<CandidateItemViewModelBuilder>()
            .As<ICandidateItemViewModelBuilder>();
    }

    private static void RegisterConstraintItemViewModel(ContainerBuilder builder)
    {
        // register constraint item view model
        builder.RegisterGeneric(typeof(AtomConstraintViewModel<>))
            .As(typeof(IConstraintItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Atom<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(FunctionConstraintViewModel<,>))
            .As(typeof(IConstraintItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Function<,>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(ListConstraintViewModel<>))
            .As(typeof(IConstraintItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.List<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(PathConstraintViewModel<,>))
            .As(typeof(IConstraintItemViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Path<,>),
                (pi, _) => pi);

        builder.RegisterType(typeof(RecordConstraintViewModel))
            .As(typeof(IConstraintItemViewModel<Item.Record>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Record),
                (pi, _) => pi);

        builder.RegisterType(typeof(UnitConstraintViewModel))
            .As(typeof(IConstraintItemViewModel<Item.Unit>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Unit),
                (pi, _) => pi);

        // register constraint item view model builder
        builder.RegisterType<ConstraintItemViewModelBuilder>()
            .As<IConstraintItemViewModelBuilder>();
    }

    public static void RegisterNymphShared(this ContainerBuilder builder)
    {
        RegisterCandidateItemViewModel(builder);

        RegisterConstraintItemViewModel(builder);
    }
}
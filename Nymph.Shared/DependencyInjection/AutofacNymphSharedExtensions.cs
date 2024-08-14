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
using Nymph.Shared.Group;
using Nymph.Shared.Group.ItemPreview;
using Nymph.Shared.Group.ListUnfold;
using Nymph.Shared.ItemPreview;
using Nymph.Shared.ItemPreview.Atom;
using Nymph.Shared.ItemPreview.Function;
using Nymph.Shared.ItemPreview.List;
using Nymph.Shared.ItemPreview.Path;
using Nymph.Shared.ItemPreview.Record;
using Nymph.Shared.ItemPreview.Unit;

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

    private static void RegisterItemPreviewViewModel(ContainerBuilder builder)
    {
        // register item preview view model
        builder.RegisterGeneric(typeof(AtomPreviewViewModel<>))
            .As(typeof(ItemPreview.IItemPreviewViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Atom<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(FunctionPreviewViewModel<,>))
            .As(typeof(ItemPreview.IItemPreviewViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Function<,>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(ListPreviewViewModel<>))
            .As(typeof(ItemPreview.IItemPreviewViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.List<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(PathPreviewViewModel<,>))
            .As(typeof(ItemPreview.IItemPreviewViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Item.Path<,>),
                (pi, _) => pi);

        builder.RegisterType(typeof(RecordPreviewViewModel))
            .As(typeof(ItemPreview.IItemPreviewViewModel<Item.Record>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Record),
                (pi, _) => pi);

        builder.RegisterType(typeof(UnitPreviewViewModel))
            .As(typeof(ItemPreview.IItemPreviewViewModel<Item.Unit>))
            .WithParameter(
                (pi, _) => pi.ParameterType == typeof(Item.Unit),
                (pi, _) => pi);

        // register item preview view model builder
        builder.RegisterType<ItemPreviewViewModelBuilder>()
            .As<IItemPreviewViewModelBuilder>();
    }

    private static void RegisterGroupViewModel(ContainerBuilder builder)
    {
        builder.RegisterGeneric(typeof(ItemPreviewViewModel<>))
            .As(typeof(IGroupViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Model.Group.ItemPreview<>),
                (pi, _) => pi);

        builder.RegisterGeneric(typeof(ListUnfoldViewModel<>))
            .As(typeof(IGroupViewModel<>))
            .WithParameter(
                (pi, _) => pi.ParameterType.IsGenericType &&
                           pi.ParameterType.GetGenericTypeDefinition() == typeof(Model.Group.ListUnfold<>),
                (pi, _) => pi);
    }

    public static void RegisterNymphShared(this ContainerBuilder builder)
    {
        RegisterCandidateItemViewModel(builder);

        RegisterConstraintItemViewModel(builder);

        RegisterItemPreviewViewModel(builder);

        RegisterGroupViewModel(builder);
    }
}
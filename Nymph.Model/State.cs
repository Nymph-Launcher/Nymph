namespace Nymph.Model;

public record State(Seq<Item> Items, string Search, Option<Item> Constraint);
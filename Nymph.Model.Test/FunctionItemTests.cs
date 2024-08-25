namespace Nymph.Model.Test;

public class FunctionItemTests
{
    [Fact]
    public void Build_FunctionItemWithoutValidation_ShouldBeNone()
    {
        var item = new Item.Function<Item.Atom<int>, Item.Atom<string>>(new Item.FunctionSemantic("Display integer"),
            number => Task.FromResult(Seq([new Item.Atom<string>($"Number is {number}")])));

        item.Validation.Should().BeNone();
    }
}
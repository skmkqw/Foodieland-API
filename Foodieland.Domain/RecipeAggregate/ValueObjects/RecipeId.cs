using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.RecipeAggregate.ValueObjects;

public class RecipeId : ValueObject
{
    public Guid Value { get; }

    private RecipeId(Guid value)
    {
        Value = value;
    }

    public static RecipeId CreateUnique()
    {
        return new RecipeId(Guid.NewGuid());
    }

    public static RecipeId Create(Guid value)
    {
        return new RecipeId(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.RecipeAggregate.ValueObjects;

public class IngredientId : ValueObject
{
    public Guid Value { get; }

    private IngredientId(Guid value)
    {
        Value = value;
    }

    public static IngredientId CreateUnique()
    {
        return new IngredientId(Guid.NewGuid());
    }

    public static IngredientId Create(Guid value)
    {
        return new IngredientId(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.IngredientAggregate.ValueObjects;

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
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
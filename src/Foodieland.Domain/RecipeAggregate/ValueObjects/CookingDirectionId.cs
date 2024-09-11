using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.Entities;

namespace Foodieland.Domain.RecipeAggregate.ValueObjects;

public class CookingDirectionId : ValueObject
{
    public Guid Value { get; }

    private CookingDirectionId(Guid value)
    {
        Value = value;
    }

    public static CookingDirectionId CreateUnique()
    {
        return new CookingDirectionId(Guid.NewGuid());
    }

    public static CookingDirectionId Create(Guid value)
    {
        return new CookingDirectionId(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
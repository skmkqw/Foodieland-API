using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.Recipe.ValueObjects;

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
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.Recipe.ValueObjects;

public class NutritionInformationId : ValueObject
{
    public Guid Value { get; }

    private NutritionInformationId(Guid value)
    {
        Value = value;
    }

    public static NutritionInformationId CreateUnique()
    {
        return new NutritionInformationId(Guid.NewGuid());
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
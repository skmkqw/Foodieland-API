using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.Recipe.ValueObjects;

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
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.ReviewAggregate.ValueObjects;

public class ReviewId : ValueObject
{
    public Guid Value { get; }

    private ReviewId(Guid value)
    {
        Value = value;
    }
    
    public static ReviewId CreateUnique()
    {
        return new ReviewId(Guid.NewGuid());
    }

    public static ReviewId Create(Guid value)
    {
        return new ReviewId(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
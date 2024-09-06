using Foodieland.Domain.Common.Models;

namespace Foodieland.Domain.Review.ValueObjects;

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
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
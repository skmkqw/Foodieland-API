using ErrorOr;

namespace Foodieland.Domain.Common.Errors;

public static partial class Errors
{
    public static class Review
    {
        public static Error DuplicateReview => Error.Conflict(
            code: "Review.Conflict",
            description: "This recipe has already been reviewed by this user");
    }
}
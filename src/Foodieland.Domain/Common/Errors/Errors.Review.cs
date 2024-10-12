using ErrorOr;

namespace Foodieland.Domain.Common.Errors;

public static partial class Errors
{
    public static class Review
    {
        public static Error NotFound => Error.NotFound(
            code: "Review.NotFound",
            description: "Review not found or doesn't exist");
        
        public static Error Unauthorized => Error.Unauthorized(
            code: "Review.Unauthorized",
            description: "You are not authorized to modify this review");
        
        public static Error DuplicateReview => Error.Conflict(
            code: "Review.Conflict",
            description: "This recipe has already been reviewed by this user");
    }
}
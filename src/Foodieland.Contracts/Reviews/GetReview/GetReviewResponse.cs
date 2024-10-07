namespace Foodieland.Contracts.Reviews.GetReview;

public record GetReviewResponse(
    string Id,
    string RecipeId,
    string CreatorId,
    int Rating,
    string Content);
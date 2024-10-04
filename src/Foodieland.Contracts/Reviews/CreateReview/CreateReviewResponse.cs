namespace Foodieland.Contracts.Reviews.CreateReview;

public record CreateReviewResponse(string RecipeId, string CreatorId, string Content, int Rating);
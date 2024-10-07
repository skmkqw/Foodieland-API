namespace Foodieland.Contracts.Reviews.CreateReview;

public record CreateReviewResponse(string Id, string RecipeId, string CreatorId, string Content, int Rating);
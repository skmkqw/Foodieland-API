namespace Foodieland.Contracts.Reviews.CreateOrUpdateReview;

public record CreateOrUpdateReviewResponse(string Id, string RecipeId, string CreatorId, string Content, int Rating);
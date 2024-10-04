using Foodieland.Application.Reviews.Commands;
using Foodieland.Contracts.Reviews.CreateReview;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Foodieland.API.Mapping;

public class ReviewMappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Guid, Guid, CreateReviewRequest => CreateReviewCommand
        config.NewConfig<(Guid recipeId, Guid creatorId, CreateReviewRequest request), CreateReviewCommand>()
            .Map(dest => dest.CreatorId, src => UserId.Create(src.creatorId))
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest, src => src.request);
        
        //Review => CreateReviewResponse
        config.NewConfig<Review, CreateReviewResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RecipeId, src => src.RecipeId.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value);
    }
}
using Foodieland.Application.Common.Models;
using Foodieland.Application.Reviews.Commands;
using Foodieland.Application.Reviews.Commands.CreateReview;
using Foodieland.Application.Reviews.Commands.UpdateReview;
using Foodieland.Application.Reviews.Queries.GetRecipeReviews;
using Foodieland.Application.Reviews.Queries.GetUserReviews;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Reviews.CreateOrUpdateReview;
using Foodieland.Contracts.Reviews.GetReview;
using Foodieland.Contracts.Reviews.GetReviews;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Mapster;

namespace Foodieland.API.Mapping;

public class ReviewMappingConfigurations : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        //Guid, Guid, CreateOrUpdateReviewRequest => CreateReviewCommand
        config.NewConfig<(Guid recipeId, Guid? creatorId, CreateOrUpdateReviewRequest request), CreateReviewCommand>()
            .Map(dest => dest.CreatorId, src => UserId.Create(src.creatorId!.Value))
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest, src => src.request);
        
        //Guid, Guid, CreateOrUpdateReviewRequest => UpdateReviewCommand
        config.NewConfig<(Guid recipeId, Guid? creatorId, CreateOrUpdateReviewRequest request), UpdateReviewCommand>()
            .Map(dest => dest.UserId, src => UserId.Create(src.creatorId!.Value))
            .Map(dest => dest.ReviewId, src => ReviewId.Create(src.recipeId))
            .Map(dest => dest, src => src.request);
        
        //Review => CreateOrUpdateReviewResponse
        config.NewConfig<Review, CreateOrUpdateReviewResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RecipeId, src => src.RecipeId.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value);
        
        //Guid, PagedResultRequest => GetRecipeReviewsRequest
        config.NewConfig<(Guid recipeId, PagedResultRequest request), GetRecipeReviewsQuery>()
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest, src => src.request);
        
        //Guid, PagedResultRequest => GetUserReviewsRequest
        config.NewConfig<(Guid userId, PagedResultRequest request), GetUserReviewsQuery>()
            .Map(dest => dest.UserId, src => UserId.Create(src.userId))
            .Map(dest => dest, src => src.request);
        
        //Review => GetReviewResponse
        config.NewConfig<Review, GetReviewResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RecipeId, src => src.RecipeId.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value);
        
        //PagedResult<Review> => GetReviewsResponse
        config.NewConfig<PagedResult<Review>, GetReviewsResponse>()
            .Map(dest => dest.Reviews, src => src.Items)
            .Map(dest => dest.PaginationResponse, src => new PaginationResponse(
                src.Page, 
                src.PageSize, 
                src.TotalCount));
    }
}
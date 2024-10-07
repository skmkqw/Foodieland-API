using Foodieland.Application.Authentication.Commands.Register;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Authentication.Queries.Login;
using Foodieland.Application.Common.Models;
using Foodieland.Contracts.Authentication;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Recipes.GetRecipes;
using Foodieland.Contracts.Reviews.GetReview;
using Foodieland.Contracts.Reviews.GetReviews;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate;
using Mapster;
using RegisterRequest = Microsoft.AspNetCore.Identity.Data.RegisterRequest;

namespace Foodieland.API.Mapping;

public class AuthenticationMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        
        config.NewConfig<LoginRequest, LoginQuery>();
        
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest, src => src.User);

        config.NewConfig<Review, GetReviewResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.RecipeId.Value))
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value);
        
        config.NewConfig<PagedResult<Review>, GetReviewsResponse>()
            .Map(dest => dest.Reviews, src => src.Items)
            .Map(dest => dest.Pagination, src => new Pagination(
                src.Page, 
                src.PageSize, 
                src.TotalCount));
    }
}
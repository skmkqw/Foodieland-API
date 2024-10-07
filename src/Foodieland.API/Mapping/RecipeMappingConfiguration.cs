using Foodieland.Application.Common.Models;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
using Foodieland.Application.Recipes.Commands.UpdateRecipe;
using Foodieland.Application.Recipes.Queries.GetRecipe;
using Foodieland.Application.Recipes.Queries.GetUserRecipes;
using Foodieland.Contracts.Common;
using Foodieland.Contracts.Recipes.CreateOrUpdateRecipe;
using Foodieland.Contracts.Recipes.GetRecipe;
using Foodieland.Contracts.Recipes.GetRecipes;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using Mapster;
using CookingDirection = Foodieland.Domain.RecipeAggregate.Entities.CookingDirection;
using Ingredient = Foodieland.Domain.RecipeAggregate.Entities.Ingredient;

namespace Foodieland.API.Mapping;

public class RecipeMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateOrUpdateRecipeRequest request, Guid? creatorId), CreateRecipeCommand>()
            .Map(dest => dest.CreatorId, src => src.creatorId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<(CreateOrUpdateRecipeRequest request, Guid? creatorId, Guid recipeId), UpdateRecipeCommand>()
            .Map(dest => dest.Id, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest.UserId, src => UserId.Create(src.creatorId!.Value))
            .Map(dest => dest, src => src.request);

        config.NewConfig<Recipe, CreateOrUpdateRecipeResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value)
            .Map(dest => dest.ReviewIds, src => src.ReviewIds.Select(id => id.Value).ToList());
        
        config.NewConfig<Recipe, GetRecipeResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value)
            .Map(dest => dest.ReviewIds, src => src.ReviewIds.Select(id => id.Value).ToList());
        
        config.NewConfig<PagedResult<Recipe>, GetRecipesResponse>()
            .Map(dest => dest.Recipes, src => src.Items)
            .Map(dest => dest.PaginationResponse, src => new PaginationResponse(
                src.Page, 
                src.PageSize, 
                src.TotalCount));
        
        config.NewConfig<CookingDirection, CookingDirectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<Ingredient, IngredientResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<(Guid recipeId, Guid? creatorId), DeleteRecipeCommand>()
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest.CreatorId, src => UserId.Create(src.creatorId!.Value));

        config.NewConfig<Guid, GetRecipeQuery>()
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src));
        
        config.NewConfig<(Guid UserId, PagedResultRequest request), GetUserRecipesQuery>()
            .Map(dest => dest.UserId, src => UserId.Create(src.UserId))
            .Map(dest => dest, src => src.request);
    }
}
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.Recipes.Commands.DeleteRecipe;
using Foodieland.Contracts.Recipes;
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
        config.NewConfig<(CreateRecipeRequest request, Guid? creatorId), CreateRecipeCommand>()
            .Map(dest => dest.CreatorId, src => src.creatorId)
            .Map(dest => dest, src => src.request);

        config.NewConfig<Recipe, CreateRecipeResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.CreatorId, src => src.CreatorId.Value)
            .Map(dest => dest.ReviewIds, src => src.ReviewIds.Select(id => id.Value).ToList());
        
        config.NewConfig<CookingDirection, CookingDirectionResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
        
        config.NewConfig<Ingredient, IngredientResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);


        config.NewConfig<(Guid recipeId, Guid? creatorId), DeleteRecipeCommand>()
            .Map(dest => dest.RecipeId, src => RecipeId.Create(src.recipeId))
            .Map(dest => dest.CreatorId, src => UserId.Create(src.creatorId!.Value));
    }
}
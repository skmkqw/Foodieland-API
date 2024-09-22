using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Contracts.Recipes;
using Foodieland.Domain.RecipeAggregate;
using Mapster;
using CookingDirection = Foodieland.Domain.RecipeAggregate.Entities.CookingDirection;
using Ingredient = Foodieland.Domain.RecipeAggregate.Entities.Ingredient;
using NutritionInformation = Foodieland.Domain.RecipeAggregate.ValueObjects.NutritionInformation;

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
    }
}
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Contracts.Recipes;
using Mapster;

namespace Foodieland.API.Mapping;

public class RecipeMappingConfiguration : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateRecipeRequest request, Guid creatorId), CreateRecipeCommand>()
            .Map(dest => dest.CreatorId, src => src.creatorId)
            .Map(dest => dest, src => src.request);
    }
}
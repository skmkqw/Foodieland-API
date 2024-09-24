using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetRecipe;

public class GetRecipeQueryHandler : IRequestHandler<GetRecipeQuery, ErrorOr<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipeQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<ErrorOr<Recipe>> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var recipe = _recipeRepository.GetRecipeById(request.RecipeId);
        
        if (recipe is null)
        {
            return Error.NotFound("Recipe.NotFound", "Recipe not found or doesn't exist");
        }
        
        return recipe;
    }
}
using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
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
        var recipe = await _recipeRepository.GetRecipeById(request.RecipeId);
        
        if (recipe is null)
        {
            return Errors.Recipe.NotFound;
        }
        
        return recipe;
    }
}
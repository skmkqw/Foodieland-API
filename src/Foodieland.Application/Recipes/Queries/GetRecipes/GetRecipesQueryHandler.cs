using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetRecipes;

public class GetRecipesQueryHandler : IRequestHandler<GetRecipesQuery, List<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;

    public GetRecipesQueryHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<List<Recipe>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        return _recipeRepository.GetRecipes(request.Page, request.PageSize);
    }
}
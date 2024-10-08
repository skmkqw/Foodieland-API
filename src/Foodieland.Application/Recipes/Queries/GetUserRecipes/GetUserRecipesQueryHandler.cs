using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Common.Models;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public class GetUserRecipesQueryHandler : IRequestHandler<GetUserRecipesQuery, ErrorOr<PagedResult<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUserRepository _userRepository;

    public GetUserRecipesQueryHandler(IRecipeRepository recipeRepository, IUserRepository userRepository)
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<PagedResult<Recipe>>> Handle(GetUserRecipesQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            return Errors.User.NotFound;
        }
        
        return await _recipeRepository.GetUserRecipes(request.UserId, request.Page, request.PageSize);
    }
}
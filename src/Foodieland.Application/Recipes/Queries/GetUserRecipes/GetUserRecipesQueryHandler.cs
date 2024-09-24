using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;
using MediatR;

namespace Foodieland.Application.Recipes.Queries.GetUserRecipes;

public class GetUserRecipesQueryHandler : IRequestHandler<GetUserRecipesQuery, ErrorOr<List<Recipe>>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUserRepository _userRepository;

    public GetUserRecipesQueryHandler(IRecipeRepository recipeRepository, IUserRepository userRepository)
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<Recipe>>> Handle(GetUserRecipesQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var user = _userRepository.GetUserById(request.UserId);

        if (user is null)
        {
            return Error.NotFound("User.NotFound", "User not found or doesn't exist");
        }
        
        return _recipeRepository.GetUserRecipes(request.UserId, request.Page, request.PageSize);
    }
}
using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.DeleteRecipe;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, ErrorOr<Unit>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;
    
    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeCreator = _userRepository.GetUserById(request.CreatorId);

        if (recipeCreator is null)
        {
            return Error.NotFound("User.NotFound", "User not found or doesn't exist");
        }
        
        var recipe = _recipeRepository.GetRecipeById(request.RecipeId);

        if (recipe is null)
        { 
            return Error.NotFound("Recipe.NotFound", "Recipe not found or doesn't exist");
        }

        if (recipe.CreatorId != request.CreatorId)
        {
            return Error.Unauthorized("Recipe.Unauthorized", "You are not authorized to delete this recipe.");
        }
        
        recipeCreator.RemoveRecipe(request.RecipeId);
        
        _recipeRepository.DeleteRecipe(recipe);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
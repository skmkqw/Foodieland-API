using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
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
        var recipeCreator = await _userRepository.GetUserById(request.CreatorId);

        if (recipeCreator is null)
        {
            return Errors.User.NotFound;
        }
        
        var recipe = await _recipeRepository.GetRecipeById(request.RecipeId);

        if (recipe is null)
        { 
            return Errors.Recipe.NotFound;
        }

        if (recipe.CreatorId != request.CreatorId)
        {
            return Errors.Recipe.Unauthorized;
        }
        
        recipeCreator.RemoveRecipe(request.RecipeId);
        
        _recipeRepository.DeleteRecipe(recipe);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
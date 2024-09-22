using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate.Events;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.DeleteRecipe;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, ErrorOr<Unit>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    public DeleteRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public async Task<ErrorOr<Unit>> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        var recipe = _recipeRepository.GetRecipeById(request.RecipeId);

        if (recipe is null)
        { 
            return Error.NotFound("Recipe.NotFound", "Recipe not found or doesn't exist");
        }

        if (recipe.CreatorId != request.CreatorId)
        {
            return Error.Unauthorized("Recipe.Unauthorized", "You are not authorized to delete this recipe.");
        }
        
        recipe.AddDomainEvent(new RecipeDeleted(recipe));
        
        _recipeRepository.DeleteRecipe(recipe);

        return Unit.Value;
    }
}
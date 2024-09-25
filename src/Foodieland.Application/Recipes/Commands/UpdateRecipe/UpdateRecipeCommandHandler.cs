using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.Entities;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, ErrorOr<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Recipe>> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipe = _recipeRepository.GetRecipeById(request.Id);

        if (recipe is null)
        {
            return Error.NotFound("Recipe.NotFound", "Recipe not found.");
        }
        
        if (recipe.CreatorId != request.UserId)
        {
            return Error.Unauthorized("Recipe.Unauthorized", "You are not authorized to modify this recipe.");
        }
        
        recipe.Update(
            name: request.Name,
            description: request.Description,
            timeToCook: request.TimeToCook,
            nutritionInformation: NutritionInformation.Create(
                calories: request.NutritionInformation.Calories, 
                fat: request.NutritionInformation.Fat, 
                carbohydrates: request.NutritionInformation.Carbs,
                protein: request.NutritionInformation.Protein),
            cookingDirections: request.Directions.ConvertAll(direction => CookingDirection.Create(
                stepNumber: direction.StepNumber,
                name: direction.Name,
                description: direction.Description)),
            request.Ingredients.ConvertAll(ingredient => Ingredient.Create(
                name: ingredient.Name,
                quantity: ingredient.Quantity,
                unit: ingredient.Unit)));
        
        _recipeRepository.UpdateRecipe(recipe);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return recipe;
    }
}
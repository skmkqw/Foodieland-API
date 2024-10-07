using ErrorOr;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.RecipeAggregate;
using Foodieland.Domain.RecipeAggregate.Entities;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;
using MediatR;

namespace Foodieland.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, ErrorOr<Recipe>>
{
    private readonly IRecipeRepository _recipeRepository;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public CreateRecipeCommandHandler(IRecipeRepository recipeRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _recipeRepository = recipeRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Recipe>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeCreator = await _userRepository.GetUserById(UserId.Create(request.CreatorId));

        if (recipeCreator is null)
        {
            return Errors.User.NotFound;
        }
        
        var recipe = Recipe.Create(
            name: request.Name,
            description: request.Description,
            timeToCook: request.TimeToCook,
            creatorId: UserId.Create(request.CreatorId),
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
                unit: ingredient.Unit))
        );
        
        recipeCreator.AddRecipe(recipe.Id);
        
        await _recipeRepository.AddRecipe(recipe);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return recipe;
    }
}
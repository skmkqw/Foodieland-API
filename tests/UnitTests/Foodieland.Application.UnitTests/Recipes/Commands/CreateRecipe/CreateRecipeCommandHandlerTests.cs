using FluentAssertions;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Recipes.Commands.CreateRecipe;
using Foodieland.Application.UnitTests.Recipes.Commands.TestUtils;
using Foodieland.Application.UnitTests.TestUtils.Recipes.Extensions;
using Moq;

namespace Foodieland.Application.UnitTests.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandlerTests
{
    private readonly CreateRecipeCommandHandler _commandHandler;
    
    private readonly Mock<IRecipeRepository> _mockRecipeRepository;

    public CreateRecipeCommandHandlerTests()
    {
        _mockRecipeRepository = new Mock<IRecipeRepository>();
        _commandHandler = new CreateRecipeCommandHandler(_mockRecipeRepository.Object);
    }
    
    [Theory]
    [MemberData(nameof(ValidCreateRecipeCommands))]
    public async Task HandleCreateRecipeCommand_WhenRecipeIsValid_ShouldCreateAndReturnRecipe(CreateRecipeCommand createRecipeCommand)
    {
        //Act
        var result = await _commandHandler.Handle(createRecipeCommand, default);

        //Assert
        result.IsError.Should().BeFalse();
        result.Value.ValidateCreatedFrom(createRecipeCommand);
        _mockRecipeRepository.Verify(m => m.Add(result.Value), Times.Once);
    }

    public static IEnumerable<object[]> ValidCreateRecipeCommands()
    {
        yield return new object[] { CreateRecipeCommandUtils.CreateCommand() };

        yield return new object[]
        {
            CreateRecipeCommandUtils
                .CreateCommand(
                    directions: CreateRecipeCommandUtils.CreateDirectionsCommand(directionCount: 3), 
                    ingredients: CreateRecipeCommandUtils.CreateIngredientsCommand(ingredientCount: 2)
                )
        };
        
        yield return new object[]
        {
            CreateRecipeCommandUtils
                .CreateCommand(
                    directions: CreateRecipeCommandUtils.CreateDirectionsCommand(directionCount: 1), 
                    ingredients: CreateRecipeCommandUtils.CreateIngredientsCommand(ingredientCount: 4)
                )
        };
        
        yield return new object[]
        {
            CreateRecipeCommandUtils
                .CreateCommand(
                    directions: CreateRecipeCommandUtils.CreateDirectionsCommand(directionCount: 2) 
                )
        };
        
        yield return new object[]
        {
            CreateRecipeCommandUtils
                .CreateCommand(
                    ingredients: CreateRecipeCommandUtils.CreateIngredientsCommand(ingredientCount: 2)
                )
        };
    }
}
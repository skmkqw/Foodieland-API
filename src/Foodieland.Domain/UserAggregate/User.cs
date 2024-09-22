using Foodieland.Domain.Common.Models;
using Foodieland.Domain.RecipeAggregate.ValueObjects;
using Foodieland.Domain.ReviewAggregate.ValueObjects;
using Foodieland.Domain.UserAggregate.ValueObjects;

namespace Foodieland.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string Password { get; }
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdateDateTime { get; }
    
    public IReadOnlyList<ReviewId> ReviewIds => _reviewIds.AsReadOnly();
    
    public IReadOnlyList<RecipeId> RecipeIds => _recipeIds.AsReadOnly();
    
    public IReadOnlyList<RecipeId> LikedRecipes => _likedRecipes.AsReadOnly();
    
    private readonly List<ReviewId> _reviewIds = new();
    
    private readonly List<RecipeId> _recipeIds = new();
    
    private readonly List<RecipeId> _likedRecipes = new();
    
    private User(
        UserId id, 
        string firstName, 
        string lastName, 
        string email, 
        string password, 
        DateTime createdDateTime,
        DateTime updateDateTime) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedDateTime = createdDateTime;
        UpdateDateTime = updateDateTime;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(
            UserId.CreateUnique(), 
            firstName, lastName,
            email, 
            password,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }

    public void AddRecipe(RecipeId recipeId)
    {
        _recipeIds.Add(recipeId);
    }

#pragma warning disable CS8618
    private User()
#pragma warning restore CS8618
    {
    }
}
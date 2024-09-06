using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Recipe.ValueObjects;
using Foodieland.Domain.Review.ValueObjects;
using Foodieland.Domain.User.ValueObjects;

namespace Foodieland.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string Password { get; }
    
    public DateTime CreatedDateTime { get; }
    
    public DateTime UpdateDateTime { get; }
    
    public IReadOnlyList<ReviewId> ReviewIds => _reviewIds.AsReadOnly();
    
    public IReadOnlyList<RecipeId> RecipeIds => _recipes.AsReadOnly();
    
    public IReadOnlyList<RecipeId> LikedRecipes => _likedRecipes.AsReadOnly();
    
    private readonly List<ReviewId> _reviewIds = new();
    
    private readonly List<RecipeId> _recipes = new();
    
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
}
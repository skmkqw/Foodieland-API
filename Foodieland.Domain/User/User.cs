using Foodieland.Domain.Common.Models;
using Foodieland.Domain.Review.ValueObjects;
using Foodieland.Domain.User.ValueObjects;

namespace Foodieland.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }

    public string LastName { get; }

    public string Email { get; }

    public string Password { get; }
    
    public IReadOnlyList<ReviewId> ReviewIds => _reviewIds.AsReadOnly();
    
    private readonly List<ReviewId> _reviewIds = new();
    
    private User(UserId id, string firstName, string lastName, string email, string password) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }

    public static User Create(string firstName, string lastName, string email, string password)
    {
        return new User(UserId.CreateUnique(), firstName, lastName, email, password);
    }
}
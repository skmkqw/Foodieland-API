using ErrorOr;
using Foodieland.Application.Common.Interfaces.Authentication;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.Entities;

namespace Foodieland.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) != null)
            return Errors.User.DuplicateEmail;

        User user = new User
        {
            Email = email,
            FirstName = firstName, 
            LastName = lastName,
            Password = password
        };
        
        _userRepository.AddUser(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (user.Password != password)
            return Errors.Authentication.InvalidCredentials;
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}
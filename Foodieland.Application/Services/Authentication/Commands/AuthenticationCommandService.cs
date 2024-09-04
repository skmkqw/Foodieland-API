using ErrorOr;
using Foodieland.Application.Common.Interfaces.Authentication;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Application.Services.Authentication.Common;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.Entities;

namespace Foodieland.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
}
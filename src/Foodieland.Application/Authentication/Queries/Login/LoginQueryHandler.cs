using ErrorOr;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Common.Interfaces.Authentication;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.Entities;
using MediatR;

namespace Foodieland.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (user.Password != query.Password)
            return Errors.Authentication.InvalidCredentials;
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        return new AuthenticationResult(user, token);
    }
}
using ErrorOr;
using Foodieland.Application.Authentication.Common;
using Foodieland.Application.Common.Interfaces.Authentication;
using Foodieland.Application.Common.Interfaces.Persistence;
using Foodieland.Domain.Common.Errors;
using Foodieland.Domain.UserAggregate;
using MediatR;

namespace Foodieland.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IPasswordHasher _passwordHasher;
    
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    
    private readonly IUserRepository _userRepository;
    
    private readonly IUnitOfWork _unitOfWork;

    public RegisterCommandHandler(
        IJwtTokenGenerator jwtTokenGenerator, 
        IUserRepository userRepository, 
        IPasswordHasher passwordHasher, 
        IUnitOfWork unitOfWork)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
            return Errors.User.DuplicateEmail;
        
        string hashedPassword = _passwordHasher.HashPassword(command.Password);    
    
        var user = User.Create(
            command.FirstName,
            command.LastName,
            command.Email,
            hashedPassword);
        
        _userRepository.AddUser(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        
        return new AuthenticationResult(user, token);
    }
}
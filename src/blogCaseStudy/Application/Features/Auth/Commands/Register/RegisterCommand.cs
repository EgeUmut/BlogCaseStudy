using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Dtos;
using NArchitecture.Core.Security.Hashing;
using NArchitecture.Core.Security.JWT;

namespace Application.Features.Auth.Commands.Register;

public class RegisterCommand : IRequest<RegisteredResponse>
{
    public RegisterDto UserForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public RegisterCommand()
    {
        UserForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public RegisterCommand(RegisterDto userForRegisterDto, string ipAddress)
    {
        UserForRegisterDto = userForRegisterDto;
        IpAddress = ipAddress;
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        IUserOperationClaimRepository _userOperationClaimRepository;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IAuthService authService,
            AuthBusinessRules authBusinessRules,
            IUserOperationClaimRepository userOperationClaimRepository
        )
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.UserForRegisterDto.Email);
            await _authBusinessRules.UserNameShouldNotExists(request.UserForRegisterDto.UserName);

            HashingHelper.CreatePasswordHash(
                request.UserForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.UserForRegisterDto.Email,
                    UserName = request.UserForRegisterDto.UserName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                };
            try
            {
                User createdUser = await _userRepository.AddAsync(newUser);

                UserOperationClaim userOperationClaim1 = new() { UserId = createdUser.Id, OperationClaimId = 24 }; // UserRole yetkisi veriliyor

                await _userOperationClaimRepository.AddAsync(userOperationClaim1);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser);

                Domain.Entities.RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(
                    createdUser,
                    request.IpAddress
                );
                Domain.Entities.RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                RegisteredResponse registeredResponse = new() { AccessToken = createdAccessToken, RefreshToken = addedRefreshToken };
                return registeredResponse;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}

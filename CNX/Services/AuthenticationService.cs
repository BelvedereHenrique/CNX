using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CNX.Configs;
using CNX.Contracts.DTO;
using CNX.Contracts.DTO.Request.Authentication;
using CNX.Contracts.Entities;
using CNX.Contracts.Enums;
using CNX.Contracts.Interfaces;
using CNX.Utils;
using Microsoft.AspNetCore.Http;

namespace CNX.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPasswordResetRepository _passwordResetRepository;
        private readonly IMapper _mapper;

        public AuthenticationService(IUserService userService,
            IEmailService emailService, 
            IHttpContextAccessor httpContextAccessor, 
            IPasswordResetRepository passwordResetRepository,
            IMapper mapper)
        {
            _userService = userService;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
            _passwordResetRepository = passwordResetRepository;
            _mapper = mapper;
        }

        public async Task<UserAuthenticationResponseDto> Authenticate(string email, string password)
        {

            var user = await _userService.GetByEmailAsync(email);

            ValidatePassword(password, user);

            var token = TokenService.GenerateToken(user.Email);

            user.Password = "";

            return new UserAuthenticationResponseDto(user.Email, token);
        }

        public async Task ResetPasswordRequestAsync(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null) return;

            var confirmationHash = Guid.NewGuid();
            var message = CreatePasswordResetEmail(email, confirmationHash);

            await _passwordResetRepository.CreateRequestAsync(user.Id, confirmationHash);

            await _emailService.SendEmailAsync(message);
        }

        public async Task ResetPasswordConfirmAsync(ResetPasswordRequestDto dto)
        {
            var user = await _userService.GetByEmailAsync(dto.Email);
            if (user != null)
            {
                var request = _mapper.Map<PasswordResetModel, PasswordResetDto>(await _passwordResetRepository.GetPasswordResetRequestAsync(user.Id));
                if (request != null && (request.Hash == dto.Hash && request.UserId == user.Id))
                {
                    await _userService.UpdatePassword(user.Id, dto.NewPassword);
                    await _passwordResetRepository.UpdatePasswordResetRequestAsync(request.Id, PasswordResetStatusEnum.Done);
                }
            }
        }

        private static void ValidatePassword(string password, UserDto userDto)
        {
            var comparePassword = EncryptionUtil.Encrypt(password);

            if (userDto == null || comparePassword != userDto.Password)
            {
                throw new HttpResponseException("Invalid e-mail or password"){Status = HttpStatusCode.Unauthorized};
            }
        }

        private MailRequestDto CreatePasswordResetEmail(string email, Guid confirmationHash)
        {
            var currentAddress = _httpContextAccessor.HttpContext.Request.Host.Value;

            var builder = new StringBuilder();

            builder.Append($"Use the following request to reset your password");
            builder.Append("<br />");
            builder.Append("<br />");
            builder.Append($"<b>Endpoint:</b> POST {currentAddress}/v1/authentication/reset/confirm");
            builder.Append("<br />");
            builder.Append("<br />");

            builder.Append("<b>Payload:</b>"); builder.Append("<br />");
            builder.Append("{"); builder.Append("<br />");
            builder.Append("&nbsp;&nbsp;&nbsp;&nbsp;"); builder.Append($"\"hash\":\"{confirmationHash}\","); builder.Append("<br />");
            builder.Append("&nbsp;&nbsp;&nbsp;&nbsp;"); builder.Append($"\"email\":\"{email}\","); builder.Append("<br />");
            builder.Append("&nbsp;&nbsp;&nbsp;&nbsp;"); builder.Append($"\"newPassword\":\"YOUR_NEW_PASSWORD\""); builder.Append("<br />");
            builder.Append("}");

            return new MailRequestDto(email, "CNX Password Reset", builder.ToString());
        }
    }
}

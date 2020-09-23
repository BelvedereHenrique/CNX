using System;

namespace CNX.Contracts.DTO.Request.Authentication
{
    public class ResetPasswordRequestDto
    {
        public Guid Hash { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }

    }
}

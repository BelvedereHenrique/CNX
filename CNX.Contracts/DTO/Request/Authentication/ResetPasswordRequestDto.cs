using System;
using System.ComponentModel.DataAnnotations;

namespace CNX.Contracts.DTO.Request.Authentication
{
    public class ResetPasswordRequestDto
    {
        [Required]
        public Guid Hash { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace CNX.Contracts.DTO.Request.Authentication
{
    public class UserAuthenticationRequestDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

namespace CNX.Contracts.DTO
{
    public class UserAuthenticationResponseDto
    {
        public UserAuthenticationResponseDto(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get; }
        public string Token { get; }
    }
}

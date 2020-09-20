namespace CNX.Contracts.DTO
{
    public class UserAuthenticationResponseDto
    {
        public UserAuthenticationResponseDto(string username, string token)
        {
            Username = username;
            Token = token;
        }

        public string Username { get; }
        public string Token { get; }
    }
}

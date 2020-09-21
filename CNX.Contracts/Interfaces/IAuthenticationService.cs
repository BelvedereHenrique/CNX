﻿using CNX.Contracts.DTO;

namespace CNX.Contracts.Interfaces
{
    public interface IAuthenticationService
    {
        UserAuthenticationResponseDto Authenticate(string email, string password);
    }
}
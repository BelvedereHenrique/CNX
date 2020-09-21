using System;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Enums;

namespace CNX.Contracts.Interfaces
{
    public interface IPasswordResetRepository
    {
        Task<PasswordResetModel> GetPasswordResetRequestAsync(int userId);
        Task CreateRequestAsync(int userId, Guid confirmationHash);
        Task UpdatePasswordResetRequestAsync(int requestId, PasswordResetStatusEnum status);
    }
}

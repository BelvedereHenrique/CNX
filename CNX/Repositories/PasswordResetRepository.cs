using System;
using System.Linq;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Enums;
using CNX.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CNX.Repositories
{
    public class PasswordResetRepository : IPasswordResetRepository
    {
        public async Task<PasswordResetModel> GetPasswordResetRequestAsync(int userId)
        {
            await using var context = new DatabaseContext();
            return await context.PasswordResets.SingleOrDefaultAsync(x => x.UserId == userId && x.Status == PasswordResetStatusEnum.Requested);
        }

        public async Task CreateRequestAsync(int userId, Guid confirmationHash)
        {
            await using var context = new DatabaseContext();

            var alreadyRequested = context.PasswordResets.Where(x => x.UserId == userId);
            await alreadyRequested.ForEachAsync(x => x.Status = PasswordResetStatusEnum.Done);

            await context.PasswordResets.AddAsync(new PasswordResetModel()
            {
                UserId = userId,
                Hash = confirmationHash,
                Status = PasswordResetStatusEnum.Requested,
                RequestedOn = DateTime.Now
            });

            await context.SaveChangesAsync();
        }

        public async Task UpdatePasswordResetRequestAsync(int requestId, PasswordResetStatusEnum status)
        {
            await using var context = new DatabaseContext();
            var request = await context.PasswordResets.SingleOrDefaultAsync(x => x.Id == requestId);
            request.Status = status;
            await context.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CNX.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<UserModel> GetById(int id)
        {
           await using var context = new DatabaseContext();
           return await context
                .Users
                .Include(x => x.Notes)
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> GetByEmail(string email)
        {
            await using var context = new DatabaseContext();
            return await context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<UserModel> CreateAsync(UserModel model)
        {
            await using var context = new DatabaseContext();
            await context.Users.AddAsync(model);
            await context.SaveChangesAsync();

            return model;
        }

        public async Task UpdatePassword(int userId, string newPassword)
        {
            await using var context = new DatabaseContext();
            var user = await context.Users.SingleOrDefaultAsync(x => x.Id == userId);

            user.Password = newPassword;

            await context.SaveChangesAsync();
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

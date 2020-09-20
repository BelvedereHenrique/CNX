using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CNX.Contracts.Entities;
using CNX.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CNX.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserModel GetById(int id)
        {
            using var context = new DatabaseContext();
            return context
                .Users
                .Include(x=>x.Notes)
                .Single(x => x.Id == id);
        }

        public UserModel GetByEmail(string email)
        {
            using var context = new DatabaseContext();
            return context.Users.Single(x => x.Email == email);
        }

        public async Task<UserModel> CreateAsync(UserModel model)
        {
            await using var context = new DatabaseContext();
            await context.Users.AddAsync(model);
            await context.SaveChangesAsync();

            return model;
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

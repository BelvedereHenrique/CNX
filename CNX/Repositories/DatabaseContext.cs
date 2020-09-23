using CNX.Configs;
using CNX.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace CNX.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<HttpLogModel> Logs { get; set; }
        public DbSet<PasswordResetModel> PasswordResets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(Settings.ConnectionString);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>().HasIndex(x => x.Email).IsUnique();
        }
    }
}

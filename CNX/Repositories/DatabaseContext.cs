using CNX.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace CNX.Repositories
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<HttpLogModel> Logs { get; set; }


        //TODO: Extrair pro config
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=DESKTOP-N0DFB0E\SQLEXPRESS;Database=cnx;User Id=sa;Password=thor;");

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserModel>().HasIndex(x => x.Email).IsUnique();
        }
    }
}

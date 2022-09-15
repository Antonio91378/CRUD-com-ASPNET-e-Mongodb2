using API.Blog.BackEnd.Domain.Entities;
using Blog.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Blog.BackEnd.Infra.Contexts
{
    public partial class Context2 : DbContext
    {
        public Context2(DbContextOptions<Context2> options) : base(options)
        {
        }

        protected Context2()
        {
        }

        public DbSet<Comment>? Comments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ApplicationSettings.GetConnectionStringEntity());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>();

            OnModelCreatingPartial(modelBuilder);
            }
            partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using API.Blog.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.BackEnd.Infra.Contexts
{
    public class Context2 : DbContext
    {
        public Context2(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comment>? comments { get; set; }
    }
}

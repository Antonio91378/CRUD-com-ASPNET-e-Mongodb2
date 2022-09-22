using API.Blog.BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Blog.BackEnd.Infra.Contexts
{
    public partial class Context2 : DbContext
    {
        public Context2(DbContextOptions<Context2> options) : base(options)
        {
        }

        public Context2()
        {
        }

        public virtual DbSet<Comment>? Comments { get; set; }
        public virtual DbSet<RepliedComment>? RepliedComments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Initial Catalog=CommentsDB; Data Source=localhost,1450; Persist Security Info=True;User ID=SA;PassWord= 2Secure*Password2");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepliedComment>()
             .HasOne(s => s.CurrentComment)
              .WithMany(g => g.RepliedComments)
               .HasForeignKey(s => s.IdComment);
        }
    }
}

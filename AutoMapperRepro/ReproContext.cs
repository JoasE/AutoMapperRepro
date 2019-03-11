using AutoMapperRepro.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperRepro
{
    public class ReproContext : DbContext
    {
        public ReproContext() : base(new DbContextOptionsBuilder<ReproContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ReproContext-1552315385;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}

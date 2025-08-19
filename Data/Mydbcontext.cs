using Goal_Mate.Configuration;
using Goal_Mate.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Goal_Mate.Data
{
    public class Mydbcontext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<UserTask> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Subtask> Subtasks { get; set; }
        public Mydbcontext(DbContextOptions<Mydbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly ( typeof ( CategoryConfigure ).Assembly );
        }
    }
}
